using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.EntityMap;
    using EMS11.Model;
    using EMS11.Model.ModelView;

    public class UserInfoController : BaseController
    {
        //
        // GET: /Admin/UserInfo/

        #region 1.0 获取用户列表
        public ActionResult Index()
        {
            var list = base.userInfoBLL.WhereAll()
                    .ToList()
                    .Select(c => c.EntityMap());

            return View(list);
        } 
        #endregion

        #region 2.0 新增用户
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfoView model)
        {
            model.u_is_lock = (int)Enums.EStatus.Normal;
            model.u_add_time = DateTime.Now;
            try
            {
                #region 1.0 由于UserInfoView实体在登录页面也使用了，如果使用ModelState.IsValid  则会出现验证码不能为空的错误,所以此处必须,指定对当前实体model中的哪些属性进行参数合法性验证,(除去了验证码Vcode)

                bool uname = ModelState.IsValidField("u_name");
                bool pwd = ModelState.IsValidField("u_pwd");
                bool realname = ModelState.IsValidField("real_name");
                bool telphone = ModelState.IsValidField("u_telephone");
                bool email = ModelState.IsValidField("u_email");

                if (
                   !uname
                   || !pwd
                   || !realname
                   || !telphone
                   || !email
                    )
                {
                    return View();
                } 
                #endregion
                //var modelstat1 = base.ModelState.Remove("VCode");


                //if (ModelState.IsValid == false)
                //{
                //    return View();
                //}

                base.userInfoBLL.Add(model.EntityMap());
                base.userInfoBLL.SaveChanges();

                return Redirect("/Admin/Userinfo/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        
        #endregion

        #region 3.0 负责检查用户名是否存在，如果存在返回false,不存在返回true
        /// <summary>
        /// 负责检查用户名是否存在，如果存在返回false,不存在返回true
        /// </summary>
        /// <returns></returns>
        public string CheckUname()
        {
            //注意：QueryString 中的key的名称应该取自UserInfoView 实体中的u_name 属性
            string uname = Request.QueryString["u_name"];

            //这里利用Any()来匹配 如果存在则返回true，但是此处应该取反以后返回
            var res = base.userInfoBLL.DbSet.Any(c => c.u_name == uname) == false;

            //注意点：一定是返回小写的true或者false
            return res.ToString().ToLower();
        } 
        #endregion

        #region 4.0 停止/启用 用户
        /// <summary>
        /// 停用用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Stop(int id)
        {
            //UserInfo uinfo = new UserInfo()
            //{
            //    user_id = id,
            //    u_is_lock = (int)Enums.EStatus.Stop
            //};
            //base.userInfoBLL.Update(uinfo, new string[] { "u_is_lock" });
            var userinfo = base.userInfoBLL.WhereByCondition(c => c.user_id == id).FirstOrDefault();
            userinfo.u_is_lock = (int)Enums.EStatus.Stop;
            base.userInfoBLL.SaveChanges();
            //var newsinfo = base.newsBLL.WhereByCondition(c => c.n_id == 1).FirstOrDefault();
            //newsinfo.n_is_lock = 1;

            //base.newsBLL.SaveChanges();

            return Json(new { status = "sucess", msg = "ok" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Start(int id)
        {
            var userinfo = base.userInfoBLL.WhereByCondition(c => c.user_id == id).FirstOrDefault();
            userinfo.u_is_lock = (int)Enums.EStatus.Normal;
            base.userInfoBLL.SaveChanges();


            return Json(new { status = "sucess", msg = "ok" }, JsonRequestBehavior.AllowGet);

        } 
        #endregion

    }
}
