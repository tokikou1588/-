﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : AsyncController
    {
        public void ArticleAsync(string name)
        {
            AsyncManager.OutstandingOperations.Increment();
            Task.Factory.StartNew(() =>
            {
                string path = ControllerContext.HttpContext.Server
                    .MapPath(string.Format(@"\articles\{0}.html", name));
                using (StreamReader reader = new StreamReader(path))
                {
                    AsyncManager.Parameters["content"] = reader.ReadToEnd();
                }
                AsyncManager.OutstandingOperations.Decrement();
            });
        }

        public ActionResult ArticleCompleted(string content)
        {
            return Content(content);
        }
    }  
}
