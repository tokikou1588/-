using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFirstHander
{
    /// <summary>
    ///P01Index
    ///注意：1、一般处理程序类一定是实现了接口   IHttpHanlder
    /// 2、一定是要执行ProcessRequest 方法，此方法中可供由程序员自己编写代码
    /// 3、  context.Response.ContentType = "text/plain"; 默认就是text/plain
    /// 
    /// </summary>
    public class P01Index : IHttpHandler
    {
        /// <summary>
        /// 由程序员自由发挥
        /// </summary>
        /// <param name="context">当前请求的上下文内容，</param>
        public void ProcessRequest(HttpContext context)
        {
            //服务器告诉浏览器如何解析发送给浏览器的响应报文体中的内容
            //text/plain:表示告诉浏览器将响应报文体中的内容当做文本来解析
            // text/html:表示告诉浏览器将响应报文体中的内容当做html来解析(创建dom节点)
            context.Response.ContentType = "text/html";

            for (int i = 0; i < 10; i++)
            {
                context.Response.Write("<h2>你好！小蛮腰!!!" + i + "</h2><br />");
            }
        }

        /// <summary>
        /// 在一般处理程序文件中IsReusable 无任何作用，可以忽略
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}