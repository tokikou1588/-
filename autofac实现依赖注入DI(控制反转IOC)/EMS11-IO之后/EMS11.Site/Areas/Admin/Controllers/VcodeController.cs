using EMS11.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using System.Drawing;

    public class VcodeController : Controller
    {
        //
        // GET: /Admin/Vcode/

        /// <summary>
        /// 负责生成验证码字符串
        /// 1、存入session["vcode"]
        /// 2、将验证码图片输出给浏览器
        /// </summary>
        /// <returns></returns>
        public ActionResult Vcode()
        {
            //1.0 生成验证码
            string vcode = GetVcode(2);

            //2.0 将验证码存入session中
            Session[Keys.Vcode] = vcode;

            byte[] imgBuffer;

            //3.0 开始将验证码生成图片
            using (Image img = new Bitmap(60, 25))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.Clear(Color.White);
                    g.DrawRectangle(Pens.Red, 0, 0, img.Width - 1, img.Height - 1);
                    g.DrawString(vcode, new Font("黑体", 16, FontStyle.Bold | FontStyle.Strikeout), new SolidBrush(Color.Blue), 0, 0);
                }


                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imgBuffer = ms.ToArray();
                }

            }
            return File(imgBuffer, "image/jpeg");
        }

        Random r = new Random();
        private string GetVcode(int num)
        {
            string[] arr = { "a", "b", "c", "2", "3", "4" };
            string res = string.Empty;
            int randMax = arr.Length - 1;
            for (int i = 0; i < num; i++)
            {
                res += arr[r.Next(randMax)];
            }

            return res;
        }

    }
}
