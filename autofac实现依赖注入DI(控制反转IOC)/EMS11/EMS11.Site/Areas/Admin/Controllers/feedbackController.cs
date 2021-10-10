using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.EntityMap;
    using EMS11.IBLL;

    /// <summary>
    /// 负责处理留言表feedback的相关数据
    /// </summary>
    public class feedbackController : BaseController
    {
        public feedbackController(
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
        // GET: /Admin/feedback/

        public ActionResult Index()
        {
            var list = base.feedbackBLL.WhereAll()
                .OrderByDescending(c => c.fadd_time)
                .Select(c => c.EntityMap());

            return View(list);
        }

    }
}
