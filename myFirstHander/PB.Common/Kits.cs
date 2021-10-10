using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Common
{
    /// <summary>
    /// 负责存放通用的工具方法
    /// </summary>
    public class Kits
    {
        /// <summary>
        /// 判断当前字符串是否为整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(string str)
        {
            int result = 0;
            return int.TryParse(str, out result);
        }

        /// <summary>
        /// 负责根据传入的key获取web.config中的AppSettings节点的对应的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingsValue(string key)
        {
            if (string.IsNullOrEmpty(key)) return string.Empty;

            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
