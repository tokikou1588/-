using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.Common
{
    /// <summary>
    /// 扩展方法管理类
    /// </summary>
    public static class ExtMethodHelper
    {

        /// <summary>
        /// 将日期格式化成年-月-日字符串返回
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateTimeFmtYYYYMMDD(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// /// 将日期格式化成  时：分：秒 字符串返回
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateTimeFmtHHMMSS(this DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }
    }
}
