using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Controllers
{
    public class ParitlViewController : BasePlatController
    {
        //
        // GET: /ParitlView/

        /// <summary>
        /// 基础类别固定为cateid= 2 ，负责提供给产品分部视图呈现数据的
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductCateList()
        {
            var clist = base.categoryBLL.WhereByCondition(c => c.c_type == 2).ToList();

            return PartialView(clist);
        }

        /// <summary>
        /// 负责获取当前企业站点的联系信息，基础数据类别id固定为9
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactPv()
        {
            var model = base.contentsBLL.DbSet.OrderByDescending(c => c.cnt_add_time).Where(c => c.category_id == 9).FirstOrDefault();


            return PartialView(model);
        }

        /// <summary>
        /// 负责呈现公司简介分部视图
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyPrd()
        {
            var list = base.contentsBLL.WhereByCondition(c => c.category_id == 8);

            return PartialView(list);
        }

    }
}
