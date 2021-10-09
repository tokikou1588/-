using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //声明一个登录窗体对象
            fmLogin fm = new fmLogin();
            //以阻断线程方式Show出来 并且等待返回值
            fm.ShowDialog();
            //接受窗体关闭时的返回值
            DialogResult res = fm.DialogResult;
            //如果返回值为我们所设置的 就new我们的主窗体
            if(res == DialogResult.OK)
            { 
            Application.Run(new fmMangeMain());
            }
        }
    }
}
