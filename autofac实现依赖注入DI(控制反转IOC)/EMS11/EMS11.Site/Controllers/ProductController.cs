using EMS11.IBLL;
using EMS11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Controllers
{
    public class ProductController : BasePlatController
    {
        public ProductController(
             ICategoryBLL categoryBLL
            , IContentsBLL contentsBLL
            , IfeedbackBLL feedbackBLL
            , IMenusBLL menusBLL
            , INewsBLL newsBLL
            , IProductBLL productBLL
            , IUserInfoBLL userInfoBLL
            )
        {
            base.categoryBLL = categoryBLL;
            base.contentsBLL = contentsBLL;
            base.feedbackBLL = feedbackBLL;
            base.menusBLL = menusBLL;
            base.newsBLL = newsBLL;
            base.productBLL = productBLL;
            base.userInfoBLL = userInfoBLL;
        }

        //
        // GET: /Product/

        /// <summary>
        /// 负责将产品数据查询出来传入index.cshtml视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            //1.0 获取url传入的参数pageindex和pagesize
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

            //2.0 给ViewBag.totalcount赋值
            ViewBag.totalcount = base.productBLL.WhereByCondition(c => c.is_lock == (int)Enums.EStatus.Normal).Count();

            //3.0 计算出当前分页应该跳过的数据行数
            int skipcount = (ipageindex - 1) * ipagesize;

            //4.0开始分页数据获取
            // var list = base.productBLL.WhereByCondition(c => c.is_lock == (int)Enums.EStatus.Normal).ToList();
            var list = base.productBLL.DbSet
                .Where(c => c.is_lock == (int)Enums.EStatus.Normal)
                .OrderByDescending(c => c.add_time)
                .Skip(skipcount)
                .Take(ipagesize);

            return View(list);
        }

        /// <summary>
        /// 负责根据产品类别来获取对应的产品数据，返回给index.cshtml视图 
        /// </summary>
        /// <param name="id">产品类别id</param>
        /// <returns></returns>
        public ActionResult productList(int id)
        {
            //TODO:请按照Index()方法自行实现本方法中的分页逻辑

            ViewBag.totalcount =10;


            var list = base.productBLL.WhereByCondition(c => c.p_id == id && c.is_lock == (int)Enums.EStatus.Normal)
                .ToList();

            return View("Index", list);
        }

        /// <summary>
        /// 负责呈现产品详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detils(int id)
        {

            var model = base.productBLL.WhereByCondition(c => c.p_id == id).FirstOrDefault();

            return View(model);

        }

    }
}
