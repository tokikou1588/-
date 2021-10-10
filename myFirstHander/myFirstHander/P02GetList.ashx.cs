using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFirstHander
{
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// P02GetList 的摘要说明
    /// </summary>
    public class P02GetList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            System.Text.StringBuilder html = new System.Text.StringBuilder(500);
            //html.Append("<style>#list{ width:600px; margin:0 auto; }</style>");
            html.Append("<table id=\"list\">");
            //初始化表格的表头
            html.Append("<tr><th>分组id</th><th>分组名称</th></tr>");

            //1.0 读取数据库表GroupInfo中的数据，返回datatable
            DataTable groupinfoList = this.GetGroupInfoList();

            //2.0 遍历datatable 中的所有行数据生成html表格<table><tr><td></tr></table>
            foreach (DataRow row in groupinfoList.Rows)
            {
                //开始生成tr标签
                html.Append("<tr><td>" + row["GroupId"] + "</td><td>" + row["GroupName"] + "</td></tr>");

            }
            html.Append("</table>");
            //3.0 将生成的表格数据存入Response对象中,响应回浏览器
            context.Response.Write(html);
        }


        private DataTable GetGroupInfoList()
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

                SqlDataAdapter sda = new SqlDataAdapter("select * from GroupInfo", conn);
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