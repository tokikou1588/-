using EMS11.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Controllers
{
    public class ContactController : BasePlatController
    {
        public ContactController(
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
        // GET: /Contact/

        /// <summary>
        /// 负责从contents表中获取类别为联系我们的数据实体传入视图callme.cshtml
        /// </summary>
        /// <returns></returns>
        public ActionResult Calme()
        {
            var model = base.contentsBLL.WhereByCondition(c => c.cnt_id == 10).FirstOrDefault();
            return View(model);
        }

    }
}
