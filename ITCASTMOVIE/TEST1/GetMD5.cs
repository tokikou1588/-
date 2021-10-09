using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TEST1
{
   static class GetMD5
    {
        public static string getMD5(string str)
        {
            MD5 md5 = MD5.Create();//通过Create方法得到MD5对象
            byte[] bytearry = System.Text.Encoding.UTF8.GetBytes(str);//编码设置
            byte[]bytemd5 = md5.ComputeHash(bytearry);//调用ComputeHash加密
            StringBuilder sb = new StringBuilder();//创建字符串拼接对象
            for (int i = 0; i < bytemd5.Length; i++)
            {
                sb.Append(bytemd5[i].ToString("x2"));//x2为十六进制加密    
            }
            return sb.ToString();
        }
        
    }
}
