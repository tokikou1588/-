using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.Common;
    using EMS11.EntityMap;
    using EMS11.Model;
    using EMS11.Model.ModelView;

    public class ContentController : CheckLoginController
    {
        //
        // GET: /Admin/Content/

        public ActionResult Index()
        {
            var list = base.contentsBLL.WhereByCondition(c => c.cnt_is_lock == (int)Enums.EStatus.Normal)
                .OrderByDescending(c=>c.cnt_add_time)
                .Select(c => c.EntityMap()).ToList();

            return View(list);
        }

        /// <summary>
        /// 负责将类别数据以SelectList 形式返回给视图
        /// </summary>
        private void SetClist()
        {
            List<Category> catelist = base.categoryBLL.WhereAll().ToList();
            SelectList slist = new SelectList(catelist, "c_id", "c_title");

            ViewBag.clist = slist;
        }

        public ActionResult Create()
        {
            SetClist();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] //禁用尖括号字符串验证检查
        public ActionResult Create(ContentsView model)
        {
            model.cnt_imgurl = "";
            model.cnt_add_time = DateTime.Now;
            model.cnt_is_lock = 0;
            model.user_id = 1;

            try
            {
                base.contentsBLL.Add(model.EntityMap());
                base.contentsBLL.SaveChanges();
                return Redirect("/Admin/Content/Index");
            }
            catch (Exception ex)
            {
                SetClist();
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            SetClist();

            var entity = base.contentsBLL.WhereByCondition(c => c.cnt_id == id).FirstOrDefault();

            return View(entity.EntityMap());
        }

        [HttpPost]
        [ValidateInput(false)] //禁用尖括号字符串验证检查
        public ActionResult Edit(int id, ContentsView model)
        {
            try
            {
                var entity = base.contentsBLL.WhereByCondition(c => c.cnt_id == id).FirstOrDefault();
                entity.cnt_title = model.cnt_title;
                entity.cnt_content = model.cnt_content;
                entity.cnt_linkurl = model.cnt_linkurl;
                entity.category_id = model.category_id;

                base.contentsBLL.SaveChanges();

                return Redirect("/Admin/Content/Index");
            }
            catch (Exception ex)
            {
                SetClist();
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }
    }
}