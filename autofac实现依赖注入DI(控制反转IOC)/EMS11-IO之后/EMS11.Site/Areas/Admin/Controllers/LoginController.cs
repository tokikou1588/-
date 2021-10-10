using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.IBLL;
    //using EMS11.AbsFactory;
    using EMS11.Model.ModelView;
    using EMS11.Common;
    using EMS11.Model;

    /// <summary>
    /// 负责进行登录处理的控制器
    /// </summary>
    public class LoginController : BaseController
    {
        public LoginController(
             ICategoryBLL categoryBLL
            , IContentsBLL contentsBLL
            , IfeedbackBLL feedbackBLL
            , IMenusBLL menusBLL
            , INewsBLL newsBLL
            , IProductBLL productBLL
            , IUserInfoBLL userInfoBLL
            )
        {
            base.categoryBLL = categoryBLL;
            base.contentsBLL = contentsBLL;
            base.feedbackBLL = feedbackBLL;
            base.menusBLL = menusBLL;
            base.newsBLL = newsBLL;
            base.productBLL = productBLL;
            base.userInfoBLL = userInfoBLL;
        }

        //
        // GET: /Admin/Login/
        /// <summary>
        /// 负责将登录视图呈现给用户
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 负责接收用户名和密码进行登录处理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UserInfoView model)
        {
            string vcodeFromSession = string.Empty;

            try
            {
                #region 0.0 验证传入参数的合法性，如果不合法ModelState.IsValid 返回false 则直接返回视图
                //由于和新增用户的功能有冲突，所以此处只验证当前登录界面传入的属性合法性
                bool uname = ModelState.IsValidField("u_name"); 
                bool pwd = ModelState.IsValidField("u_pwd");
                bool vcode = ModelState.IsValidField("VCode");

                if (!uname || !pwd || !vcode)
                {
                    return View();
                }
                #endregion

                #region 1.0 先判断session是否正确

                if (Session[Keys.Vcode] != null)
                {
                    vcodeFromSession = Session[Keys.Vcode].ToString();
                }

                if (string.IsNullOrEmpty(vcodeFromSession)
                    || vcodeFromSession.Equals(model.VCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    ModelState.AddModelError("", "验证码不正确");
                    return View();
                }

                #endregion

                #region 2.0 判断用户名和密码是否正确

                UserInfo userinfo = userInfoBLL.Login(model.u_name, Kits.MD5Entry(model.u_pwd));
                if (userinfo == null)
                {
                    ModelState.AddModelError("", "用户名和密码不正确");
                    return View();
                }

                Session[Keys.Uinfo] = userinfo;

                #endregion

                #region 3.0 登录成功以后 跳转到类别列表页面

                return Redirect("/Admin/Cate/Index");

                #endregion
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
