using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailClass
{
    public class Email
    {

       public static bool SendEmail()
        {

           
            MailMessage mail = new MailMessage(); //定义一个邮件
            //指定标题的编码格式
            mail.SubjectEncoding = System.Text.Encoding.GetEncoding("gb2312");
            //指定正文的编码格式
            mail.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312");
            //指定摘要的编码格式
            mail.HeadersEncoding = System.Text.Encoding.GetEncoding("gb2312");
            //发件人
            mail.From = new MailAddress("njgzs@126.com", "健哥");
           //收件人
            mail.To.Add(new MailAddress("njgzs@qq.com"));
            //邮件标题
            mail.Subject = "欢迎您成为我们的一员";
             //邮件正文
            mail.Body = "你好，欢迎您成为我们中的一员，您的账户为，密码为 请注意保密！";
            //定义Smtp协议对象
            SmtpClient client = new SmtpClient("126.com", 25);
            //验证发件人的用户名和密码
            client.Credentials = new NetworkCredential("njgzs@126.com", "1234567");
            //发送邮件
            try
            {
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

  
    }
}
