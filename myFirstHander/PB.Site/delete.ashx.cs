using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PB.Site
{
    using PB.Common;
    using System.Data.SqlClient;

    /// <summary>
    /// delete 的摘要说明
    /// </summary>
    public class delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //1.0 获取url传入的id参数值
            string id = context.Request.QueryString["id"];

            //1.0 验证id参数的合法性
            if (Kits.IsInt(id) == false)
            {
                context.Response.Write("<script>alert('当前id参数不合法，请重新提交');window.location='getlist.ashx'</script>");
                return;
            }
            //2.0 根据id值执行删除操作(软删除，逻辑删除)
            string updsql = "update ContactInfo set isdelete=1 where id=@id";

            SqlParameter prma = new SqlParameter("@id", id);
            DbHelperSQL.ExecuteSql(updsql, prma);
            //3.0 通过response.write()将提示语响应给浏览器
            //context.Response.Write("<script>alert('恭喜，数据删除成功')</script>");
            //Redirect:可以执行页面跳转，本质是在响应报文头中增加了指令集 Location: 要跳转的url
            //context.Response.Redirect("getlist.ashx");

            //本质:在响应报文体中将js代码发送回浏览器，再有浏览器执行js代码进行跳转操作
            context.Response.Write("<script>alert('恭喜，数据删除成功');window.location='getlist.ashx'</script>");
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