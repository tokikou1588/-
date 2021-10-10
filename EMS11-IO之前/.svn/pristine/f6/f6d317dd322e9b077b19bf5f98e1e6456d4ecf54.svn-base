using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.Common;

    /// <summary>
    /// 负责做登录检查，Login控制器不应该继承此类
    /// </summary>
    public class CheckLoginController : BaseController
    {
        /// <summary>
        /// 实现统一登录验证检查
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //实现登录检查
            if (Session[Keys.Uinfo] == null)
            {
                RedirectResult tourl = new RedirectResult("/Admin/Login/Login");
                //filterContext.Result = tourl;
            }
        }
    }
}
