using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.Model
{
    /// <summary>
    /// 用来管理当前项目中所有的枚举 将来外部可以通过 Enums.EStatus
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// 用来管理状态值的 0:正常  1:停用（软删除）
        /// </summary>
        public enum EStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 0,
            /// <summary>
            /// 停用（软删除）
            /// </summary>
            Stop = 1
        }


    }
}
