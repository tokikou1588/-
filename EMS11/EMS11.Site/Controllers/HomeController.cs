using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Controllers
{
    using EMS11.AbsFactory;
    using EMS11.IBLL;
    using EMS11.Model;

    public class HomeController : Controller
    {
        IUserInfoBLL ubll;
        AbsFactor absBll = AbsFactor.CreateBllFactory();
        public HomeController()
        {
            //ubll = Factor.Create_UserInfoBll_Instance();
            ubll = absBll.Create_UserInfoBll_Instance();
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var userinfomodel = ubll.WhereAll().FirstOrDefault();

            return Content(userinfomodel.u_name);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
