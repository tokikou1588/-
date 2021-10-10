using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Controllers
{
    public class ContactController : BasePlatController
    {
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
