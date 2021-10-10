using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PB.Site
{
    using PB.Common;
    using System.Data;

    /// <summary>
    /// add 的摘要说明
    /// </summary>
    public class add : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string method = context.Request.HttpMethod.ToLower();

            if (method == "get")
            {
                ProcessGet();
            }
            else if (method == "post")
            {
                ProcessPost();
            }
        }

        /// <summary>
        /// 负责get请求的处理后将新增页面代码发回给浏览器
        /// </summary>
        private void ProcessGet()
        {
            //1.0 获取表GroupInfo中的所有数据
            string sql = "select * from GroupInfo";
            DataTable Grouptb = DbHelperSQL.GetDataTable(sql);
            System.Text.StringBuilder groupsOption = new System.Text.StringBuilder(200);
            foreach (DataRow row in Grouptb.Rows)
            {
                groupsOption.Append("<option value='" + row["GroupId"] + "'>" + row["GroupName"] + "</option>");
            }

            //2.0 获取模板add.html页面的内容 /templates/add.html":是从网站根目录开始查找， templates/add.html：从当前add.ashx所在的路径文件夹开始查找
            string phyPath = HttpContext.Current.Server.MapPath("/templates/add.html");
            string Text = System.IO.File.ReadAllText(phyPath);  //text中有占位符 ${groups}

            //3.0 替换模板页内容中的占位符${groups}
            Text = Text.Replace("${groups}", groupsOption.ToString());

            //4.0 响应会浏览器
            HttpContext.Current.Response.Write(Text);
        }

        /// <summary>
        /// 负责post请求的处理
        /// </summary>
        void ProcessPost()
        {
            // 1.0 接收参数
            string cname = HttpContext.Current.Request.Form["cname"];
            string cphone = HttpContext.Current.Request.Form["cphone"];
            string groupid = HttpContext.Current.Request.Form["groupid"];

            // 2.0 拼装sql语句
            string insertSql = "insert into ContactInfo (ContactId,IsDelete,Account,ContactName,CommonMobile,GroupId) values ('a',0,'abc','" + cname + "','" + cphone + "'," + groupid + ")";
            DbHelperSQL.ExecuteSql(insertSql);

            //3.0 提示用户
            HttpContext.Current.Response.Write("<script>alert('恭喜，数据新增成功');window.location='getlist.ashx'</script>");
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