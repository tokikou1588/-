using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.EntityMap;
    using EMS11.Model.ModelView;

    public class CateController : CheckLoginController
    {
        //
        // GET: /Admin/Cate/

        #region 1.0 获取列表
        /// <summary>
        /// 负责获取类别表Category的所有数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //获取当前表数据的总条数
            ViewBag.totalcount = base.categoryBLL.DbSet.Count();
            //1.0 从url获取相关参数
            string pageindex = Request.QueryString["pageindex"];
            string pagesize = Request.QueryString["pagesize"];

            //2.0 开始初始化页码和每页显示的条数
            int ipageindex;
            int ipagesize;

            if (int.TryParse(pageindex, out ipageindex) == false)
            {
                ipageindex = 1;
            }

            if (int.TryParse(pagesize, out ipagesize) == false)
            {
                ipagesize = 5;
            }

            //3.0 计算出当前分页应该跳过的数据行数
            int skipcount = (ipageindex - 1) * ipagesize;

            //4.0 实现分页逻辑代码
            var list = base.categoryBLL.DbSet.OrderByDescending(c => c.c_id).Skip(skipcount).Take(ipagesize).ToList();
            var listModelView = list.Select(c => c.EntityMap());

            return View(listModelView);
        }
        #endregion

        #region 2.0 新增逻辑
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(CategoryView model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View();
                }

                //1.0 利用EF做新增操作
                base.categoryBLL.Add(model.EntityMap());
                base.categoryBLL.SaveChanges();

                return Redirect("/Admin/Cate/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }
        #endregion

        #region 3.0 编辑逻辑

        public ActionResult Edit(int id)
        {
            //根据id从数据库中查询出分类数据实体Category，再通过EntityMap()方法转换成CategoryView实体
            var model = base.categoryBLL.WhereByCondition(c => c.c_id == id).FirstOrDefault().EntityMap();

            //将CategoryView实体 传入视图Edit.cshtml中
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryView model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View();
                }

                model.c_id = id;
                base.categoryBLL.Update(model.EntityMap(), new string[] { "c_type", "c_title" });
                base.categoryBLL.SaveChanges();

                return Redirect("/Admin/Cate/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                return View();
            }
        }

        #endregion

    }
}
