using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    public class ExceptionController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //TODo:统一日志处理，可以写入数据库也可以写入日志文件
            //filterContext.Result = new RedirectResult("/Areas/Admin/Views/Shared/Error.cshtml");
            //filterContext.ExceptionHandled = false;
            base.OnException(filterContext);
        }
    }
}