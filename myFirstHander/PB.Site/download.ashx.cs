using PB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PB.Site
{
    /// <summary>
    /// 负责下载附件
    /// </summary>
    public class download : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //1.0 获取要下载的文件名称
            string fileName = context.Request.QueryString["attfile"];

            // 2.0 根据文件名去服务器硬盘路径 /upload/text 查找对应的文件，将内容发回给浏览器
            string virtualPath = Kits.GetAppSettingsValue("downloadPath") + fileName; // /upload/text/aa.txt
            //根据虚拟路径（是由web.config中的配置 + filename得到的）获取物理路径
            string phyPath = context.Server.MapPath(virtualPath);

            //3.0.1 判断当前 phyPath 所对应的文件是否存在
            if (System.IO.File.Exists(phyPath) == false)
            {
                //注意：由于前面的类型为文件下载，而此时是要提示用户，应该改回为html来解析
                context.Response.ContentType = "text/html";

                context.Response.Write("<script>alert('抱歉！没有找到你要下载的文件，请上传');window.location='/getlist.ashx';</script>");
                return;
            }

            //4.0 设置当前的ContentType 为application/octet-stream ,表示当前响应报文体重的内容是作为下载使用
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            
            //5.0 通过WriteFile()方法传入当前文件的物理路劲就可以将其内容响应会浏览器
            context.Response.WriteFile(phyPath);
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