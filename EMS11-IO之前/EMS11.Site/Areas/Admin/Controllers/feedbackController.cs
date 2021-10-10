using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.EntityMap;

    /// <summary>
    /// 负责处理留言表feedback的相关数据
    /// </summary>
    public class feedbackController : BaseController
    {
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
