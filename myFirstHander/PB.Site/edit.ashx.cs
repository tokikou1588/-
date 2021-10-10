using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PB.Site
{
    using PB.Common;
    using System.Data.SqlClient;
    using System.Data;

    /// <summary>
    /// 负责处理联系人的编辑操作
    /// </summary>
    public class edit : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string httpMethod = context.Request.HttpMethod.ToLower();

            if (httpMethod == "get")
            {
                #region 1.0 Get方法所处理的逻辑


                //1.0 根据ID参数值获取数据表ContactInfo中相应的数据，替换模板edit.html中的占位符，响应回浏览器

                //1.0.1 先获取url的id参数值
                string id = context.Request.QueryString["id"];

                //1.0.2 id 合法性验证，此时id应该为整型值
                int res = 0;
                if (int.TryParse(id, out res) == false)
                {
                    //提示用户id参数不合法,并且跳转到列表页面
                    context.Response.Write("<script>alert('参数不合法');window.location='getlist.ashx'</.script>");
                    //直接跳出当前方法的执行
                    return;
                }

                //1.0.3 根据id值从数据库中获取数据
                SqlParameter[] pams = new SqlParameter[]{
            new SqlParameter("@id",id)
            };
                DataTable dt = DbHelperSQL.GetDataTable("select * from ContactInfo where id=@id", pams);

                DataRow row = dt.Rows[0];
                //获取当前id所对应的练习人所在的组id
                string groupIdFromDB = Convert.ToString(row["GroupID"]);

                //1.0.4 获取数据表groupinfo中的所有数据
                string sql = "select * from GroupInfo";
                DataTable tb = DbHelperSQL.GetDataTable(sql);
                System.Text.StringBuilder groupOptions = new System.Text.StringBuilder(200);
                foreach (DataRow grouprow in tb.Rows)
                {
                    if (groupIdFromDB == grouprow["GroupId"].ToString())
                    {
                        groupOptions.Append("<option selected='selected' value='" + grouprow["GroupId"] + "'>" + grouprow["GroupName"] + "</option>");
                    }
                    else
                    {
                        groupOptions.Append("<option value='" + grouprow["GroupId"] + "'>" + grouprow["GroupName"] + "</option>");
                    }
                }

                // 1.0.5 将dt中的内容一一替换到模板中的相关占位符
                string phyPath = context.Server.MapPath("/templates/edit.html");
                string contentText = System.IO.File.ReadAllText(phyPath);
                contentText = contentText.Replace("${cname}", row["ContactName"].ToString())
                    .Replace("${cphone}", row["CommonMobile"].ToString())
                    .Replace("${id}", row["ID"].ToString())
                    .Replace("${groups}", groupOptions.ToString());

                context.Response.Write(contentText);
                #endregion
            }
            else if (httpMethod == "post")
            {
                #region 2.0 Post方法所处理的逻辑,接收浏览器发送过来的最新数据跟新到数据表ContactInfo中

                //1.0 接收浏览器传入服务器的参数
                string id = context.Request.Form["id"];
                string cname = context.Request.Form["cname"];
                string cphone = context.Request.Form["cphone"];
                string groupid = context.Request.Form["groupid"];

                //2.0 参数合法性验证

                // 3.0 根据参数拼装成跟新sql语句
                string updSql = "update ContactInfo set ContactName=@ContactName,CommonMobile=@CommonMobile,groupid=@groupid where id=@id";
                SqlParameter[] pamrs = new SqlParameter[] { 
                new SqlParameter("@ContactName",cname),
                new SqlParameter("@CommonMobile",cphone),
                new SqlParameter("@id",id),
                new SqlParameter("@groupid",groupid)
                };

                DbHelperSQL.ExecuteSql(updSql, pamrs);

                // 4.0 提醒用户更新成功,同时要返回到列表页面
                context.Response.Write("<script>alert('恭喜！数据编辑成功');window.location='getlist.ashx'</script>");

                #endregion
            }
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