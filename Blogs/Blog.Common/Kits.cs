using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common
{
    public class Kits
    {
        public static bool IsInt(string str)
        {
            //入参的检验
            if (string.IsNullOrEmpty(str)) return false;

            int res = 0;
            return int.TryParse(str, out res);
        }
    }
}
