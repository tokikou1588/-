using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFirstHander.getRquestDemo
{
    /// <summary>
    /// P03GetOperator get请求相关知识点演示
    /// </summary>
    public class P03GetOperator : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //1.0 动态获取当前http请求方法是get还是post
            string httpMethod = context.Request.HttpMethod;

            //2.0 在服务器端接收浏览器通过url传的参数 例如:http://localhost:8515/P02GetList.ashx?id=100&name=ivan
            string id = context.Request.QueryString["id"];
            string name = context.Request.QueryString["name"];
            string id1 = context.Request.Params["id"];


            context.Response.Write("当前请求的方式为：" + httpMethod + "<br /> 获取get请求传入的参数id=" + id + "  ,name=" + name);
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
