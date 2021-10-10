using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.Common;
    using EMS11.EntityMap;
    using EMS11.IBLL;
    using EMS11.Model;
    using EMS11.Model.ModelView;

    public class NewsController : CheckLoginController
    {
        public NewsController(
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
        // GET: /Admin/News/

        public ActionResult Index()
        {
            //计算出总条数
            ViewBag.totalcount = base.newsBLL.DbSet.Count(c => c.n_is_lock == (int)Enums.EStatus.Normal);

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
                ipagesize = 10;
            }

            //3.0 计算出当前分页应该跳过的数据行数
            int skipcount = (ipageindex - 1) * ipagesize;

            var list = base.newsBLL
                .WhereByCondition(c => c.n_is_lock == (int)Enums.EStatus.Normal)
                .OrderByDescending(c => c.add_time)
                .Skip(skipcount)
                .Take(ipagesize)
                .ToList();

            var nlist = list.Select(c => c.EntityMap());

            return View(nlist);
        }

        /// <summary>
        /// 负责将类别数据以SelectList 形式返回给视图
        /// </summary>
        private void SetClist()
        {
            List<Category> catelist = base.categoryBLL.WhereAll().ToList();
            SelectList slist = new SelectList(catelist, "c_id", "c_title");

            ViewBag.clist = slist;
        }

        public ActionResult Edit(int id)
        {
            SetClist();

            var model = base.newsBLL.WhereByCondition(c => c.n_id == id).FirstOrDefault().EntityMap();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]//禁用客户端尖括号的检查
        public ActionResult Edit(int id, NewsView model)
        {
            try
            {

                if (ModelState.IsValid == false)
                {
                    SetClist();
                    return View();
                }

                //开始正常逻辑处理
                var entity = base.newsBLL.WhereByCondition(c => c.n_id == id).FirstOrDefault();
                entity.n_title = model.n_title;
                entity.category_id = model.category_id;
                entity.n_content = model.n_content;

                base.newsBLL.SaveChanges();

                return Redirect("/Admin/News/Index");

            }
            catch (Exception ex)
            {
                SetClist();
                ModelState.AddModelError("", ex.Message);
                return View();
            }


        }

    }
}
