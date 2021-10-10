using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFirstHander.postRequestDemo
{
    /// <summary>
    /// P04PostOperator 的摘要说明
    /// </summary>
    public class P04PostOperator : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string httpMethod = context.Request.HttpMethod;
            string id = context.Request.Form["id"];
            string name = context.Request.Form["name"];
            string id1 = context.Request.Params["id"];
            string url = context.Request.Params["url"];
            

            context.Response.Write("当前请求的方式为：" + httpMethod + "<br /> 获取Post请求传入的参数id=" + id1 + "  ,name=" + name + "<br />url=" + url);
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