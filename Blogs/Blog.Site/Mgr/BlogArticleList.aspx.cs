using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.Site.Mgr
{
    using Blog.BLL;
    using System.Data;

    public partial class BlogArticleList : System.Web.UI.Page
    {
        BlogArticleBLL bll = new BlogArticleBLL();
        /// <summary>
        /// trs 用来存放<tr><td></td></tr>
        /// </summary>
        protected System.Text.StringBuilder trs = new System.Text.StringBuilder(500);

        protected void Page_Load(object sender, EventArgs e)
        {
            // 1.0 从数据表中读取播客文章
            DataTable tb = bll.GetListJoin(" b.AIsDel = 0 ");

            // 2.0 遍历数据表一一生成tr标签 追加到trs中，供aspx页面使用
            foreach (DataRow row in tb.Rows)
            {
                trs.Append("<tr><td><input type='checkbox' name='chk' value='"+row["AId"]+"' /></td>");
                trs.Append("<td>" + row["AId"] + "</td>");
                trs.Append("<td>" + row["Name"] + "</td>");
                trs.Append("<td>" + row["ATitle"] + "</td>");
                trs.Append("<td>" + row["e_cname"] + "</td>");
                trs.Append("<td>" + row["AAddtime"] + "</td>");
                trs.Append("<td><a>编辑</a> | <a>删除</a></td>");
                trs.Append("</tr>");
                
            }
        }
    }
}