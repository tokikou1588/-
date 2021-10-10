using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Controllers
{
    using EMS11.Model;
    using EMS11.EntityMap;
    using EMS11.Model.ModelView;
    using EMS11.IBLL;

    public class HomeController : BasePlatController
    {
        public HomeController(
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

        /// <summary>
        /// 负责展示企业管理站点首页视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //1.0 加载的行业新闻和公司新闻列表分别以ViewBag.hynews，ViewBag.compNews 返回
            ViewBag.hynews = base.newsBLL.DbSet
                .Where(c=>c.category_id == 2)
                .OrderByDescending(c=>c.add_time)
                .Skip(0).Take(6).ToList();


            ViewBag.cnews = base.newsBLL.DbSet
                .Where(c=>c.category_id == 1)
                    .OrderByDescending(c => c.add_time)
                .Skip(0).Take(6).ToList();

            return View();
        }

     
    }
}
