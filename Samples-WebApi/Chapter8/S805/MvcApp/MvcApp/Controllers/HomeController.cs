﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ShowNonExistentView()
        {
            return View("NonExistentView");
        }

        public ActionResult ShowStaticFileView()
        {
            return View();
        }
    }
}
