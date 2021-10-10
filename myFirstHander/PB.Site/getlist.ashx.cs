using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PB.Site
{
    using PB.Common;
    using System.Data;

    /// <summary>
    /// getlist 的摘要说明
    /// </summary>
    public class getlist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            System.Text.StringBuilder trsHtml = new System.Text.StringBuilder(200);
            //获取表ContactInfo表的数据2
            //DataTable tb = DbHelperSQL.GetDataTable("select * from ContactInfo  where IsDelete = 0", null);
            string sql = "select c.*,isnull(g.GroupName,'') as GroupName from ContactInfo c  left join GroupInfo g on (c.GroupId=g.GroupId) where c.IsDelete=0";
            DataTable tb = DbHelperSQL.GetDataTable(sql);
            //2.0 遍历tb中的所有行
            foreach (DataRow row in tb.Rows)
            {
                trsHtml.Append("<tr>");
                trsHtml.Append("<td>" + row["ID"] + "</td>");
                trsHtml.Append("<td>" + row["ContactName"] + "</td>");
                trsHtml.Append("<td>" + row["CommonMobile"] + "</td>");
                trsHtml.Append("<td>" + row["GroupName"] + "</td>");
                trsHtml.Append("<td><a href='edit.ashx?id=" + row["ID"] + "'>编辑</a> | <a onclick='del(" + row["ID"] + ")' href='javascript:void(0);'>删除</a>   | <a  href='/download.ashx?attfile="+row["AttFile"]+"'>附件下载</a></td>");
                trsHtml.AppendLine("</tr>");
            }

            //3.0 读取模板内容并且替换其中的占位符${trs}
            string phyPath = context.Server.MapPath("/templates/list.html");
            string contentText = System.IO.File.ReadAllText(phyPath);
            contentText = contentText.Replace("${trs}", trsHtml.ToString());

            context.Response.Write(contentText);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}