using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    //using EMS11.AbsFactory;
    using EMS11.IBLL;

    /// <summary>
    /// 负责实例化抽象工厂对象以及初始化所有的业务实现者对象
    /// </summary>
    public class BaseController : ExceptionController
    {
        #region 1.0 实例化抽象工厂类的具体实现业务工厂类
        /// <summary>
        /// 实例化抽象工厂类的具体实现业务工厂类
        /// </summary>
        //AbsFactor absFactor = AbsFactor.CreateBllFactory();
        #endregion

        #region 2.0 利用抽象工厂对象创建所有的业务实现者以其接口的形式返回

        public ICategoryBLL categoryBLL;
        public IContentsBLL contentsBLL;
        public IfeedbackBLL feedbackBLL;
        public IMenusBLL menusBLL;
        public INewsBLL newsBLL;
        public IProductBLL productBLL;
        public IUserInfoBLL userInfoBLL;

        //public BaseController(
        //     ICategoryBLL categoryBLL
        //    , IContentsBLL contentsBLL
        //    , IfeedbackBLL feedbackBLL
        //    , IMenusBLL menusBLL
        //    , INewsBLL newsBLL
        //    , IProductBLL productBLL
        //    , IUserInfoBLL userInfoBLL
        //    )
        //{
        //    this.categoryBLL = categoryBLL;
        //    this.contentsBLL = contentsBLL;
        //    this.feedbackBLL = feedbackBLL;
        //    this.menusBLL = menusBLL;
        //    this.newsBLL = newsBLL;
        //    this.productBLL = productBLL;
        //    this.userInfoBLL = userInfoBLL;
        //}


        #endregion

    }
}