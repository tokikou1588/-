using EMS11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.EntityMap;
    using EMS11.IBLL;

    public class MenusController : CheckLoginController
    {
        public MenusController(
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
        // GET: /Admin/Menus/

        public ActionResult Index()
        {
          var list=  base.menusBLL.WhereByCondition(c => c.m_status == (int)Enums.EStatus.Normal)
                .ToList()
                .Select(c=>c.EntityMap());

          return View(list);
        }

        /// <summary>
        /// 负责去menus表中获取所有的数据，返回一个分部视图GetMenus
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenus()
        {
            //1.0 先获取menus表的所有数据集合
            //1.0.1 先将菜单按照m_sortid 进行正序排列
            var menusList = base.menusBLL.DbSet.Where(c => c.m_status == (int)Enums.EStatus.Normal).OrderBy(c => c.m_sortid).ToList();

            return PartialView(menusList);
        }

    }
}
