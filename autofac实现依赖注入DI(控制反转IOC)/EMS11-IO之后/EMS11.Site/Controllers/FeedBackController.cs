using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Controllers
{
    using EMS11.Model.ModelView;
    using EMS11.EntityMap;
    using EMS11.Model;
    using EMS11.IBLL;

    public class FeedBackController : BasePlatController
    {
        public FeedBackController(
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
        // GET: /FeedBack/

        /// <summary>
        /// 客户留言提交
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 客户留言提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(feedbackView model)
        {
            model.fuser_qq = "";
            model.fuser_email = "";
            model.fadd_time = DateTime.Now;
            model.freply_content = "";
            model.freply_time = DateTime.Now;
            model.is_lock = false;
            try
            {

                if (ModelState.IsValid == false)
                {
                    return View();
                }

                //开始正常处理逻辑（相当于做新增操作 ）
                base.feedbackBLL.Add(model.EntityMap());
                base.feedbackBLL.SaveChanges();

                return Content("<script>alert('恭喜，您的留言我们将会尽快回复');window.location=window.location;</script>");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }

            return View();
        }

    }
}
