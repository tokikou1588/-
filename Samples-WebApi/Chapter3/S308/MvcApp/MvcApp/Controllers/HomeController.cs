﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            Response.Write("这是一个通过ReflelctionControllerFactory激活的Controller！");
        }
    }
}
