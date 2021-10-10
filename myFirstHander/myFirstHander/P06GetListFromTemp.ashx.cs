using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFirstHander
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    /// <summary>
    /// P06GetListFromTemp 的摘要说明
    /// 注意：在测试此页面的时候，应该以http://localhost:8515/P06GetListFromTemp.ashx?id=209
    /// </summary>
    public class P06GetListFromTemp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            // 0.0 获取浏览器通过url传入的id参数的值
            string id = context.Request.QueryString["id"];

            //trsHtml 用来存放下面第2步产生的字符串
            StringBuilder trsHtml = new StringBuilder(200);

            //1.0  读取数据表GroupInfo中的所有数据以datatable返回
            DataTable tb = this.GetGroupInfoList(id);

            //2.0 遍历datatable 将每行数据拼装成<tr><td></td><td></td></tr>
            foreach (DataRow row in tb.Rows)
            {
                // trsHtml.Append("<tr><td>" + row["GroupId"] + "</td><td>" + row["GroupName"] + "</td></tr>");
                trsHtml.Append("<tr>");
                trsHtml.Append("<td>" + row["GroupId"] + "</td>");
                trsHtml.Append("<td>" + row["GroupName"] + "</td>");
                trsHtml.Append("</tr>");
            }

            //3.0  读取模板页面listtmp.html中的所有内容，并且将其中的占位符${trs}替换成trsHtml 中的字符串
            //3.0.1 、获取模板listtmp.html 的物理路径
            string phyPath = context.Server.MapPath("listtmp.html");
            //3.0.2 根据物理路径phyPath 获取模板的内容
            string contentText = System.IO.File.ReadAllText(phyPath);
            //3.0.3 将contentText 中的占位符${trs}替换成trsHtml 中的所有字符串
            contentText = contentText.Replace("${trs}", trsHtml.ToString());

            // 4.0  将第三步生成的文本字符串写入到Response中,响应给浏览器
            context.Response.Write(contentText);
        }

        private DataTable GetGroupInfoList(string id)
        {
            DataSet ds = new DataSet();

            //1.0 先读取web.config中配置好的数据库连接字符串
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["phoneConnstring"].ConnectionString;
            // 2.0 创建连接
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                //3.0 打开数据库连接
                conn.Open();
                //4.0  读取数据
                SqlDataAdapter sda = new SqlDataAdapter("select * from GroupInfo where groupid=@groupid", conn);
                sda.SelectCommand.Parameters.Add(new SqlParameter("@groupid", id));
                sda.Fill(ds);
            }
            return ds.Tables[0];
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