using EMS11.IBLL;
using EMS11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Controllers
{
    public class NewsController : BasePlatController
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
        // GET: /News/
        public ActionResult Index()
        {
            //包括行业新闻和公司新闻,分页未实现
            var newslist = base.newsBLL.WhereByCondition(c => c.n_is_lock == (int)Enums.EStatus.Normal).ToList();

            return View(newslist);
        }

        /// <summary>
        /// 负责呈现某个新闻的详细
        /// </summary>
        /// <returns></returns>
        public ActionResult Detils(int id)
        {
            var model = base.newsBLL.WhereByCondition(c => c.n_id == id).FirstOrDefault();

            return View(model);
        }

        /// <summary>
        /// 负责查询公司新闻
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyNews()
        {
            //由于数据库的基础数据中公司新闻的id =1 ，所以在此处可以直接筛选出 cateid=1的所有新闻数据即可
            var newlist = base.newsBLL.WhereByCondition(c => c.n_is_lock == (int)Enums.EStatus.Normal
                && c.category_id == 1).ToList();
            return View("Index", newlist);
        }

        /// <summary>
        /// 负责查询行业新闻
        /// </summary>
        /// <returns></returns>
        public ActionResult HangYeNews()
        {
            //由于数据库的基础数据中行业新闻的id =2 ，所以在此处可以直接筛选出 cateid=1的所有新闻数据即可
           // var newlist = base.newsBLL.WhereByCondition(c => c.n_is_lock == (int)Enums.EStatus.Normal
            //&& c.category_id == 2).ToList();

            var newlist = (from c in base.newsBLL.DbSet
                           where c.n_is_lock == (int)Enums.EStatus.Normal
                           && c.category_id == 2
                           select c).ToList();

            //var newlist = (from c in base.newsBLL.DbSet
            //               where c.n_is_lock == (int)Enums.EStatus.Normal
            //               where c.category_id == 2
            //               select c).ToList();

            return View("Index", newlist);
        }

    }
}
