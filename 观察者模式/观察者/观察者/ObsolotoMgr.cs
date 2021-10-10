using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者
{
    public delegate void DObs();

    public class ObsolotoMgr
    {
        public static event DObs objHandler;

        public static void Action()
        {
            if (objHandler != null)
            { 
                //触发注册在当前事件上的所有方法
                objHandler.Invoke();
            }
        }
    }
}
