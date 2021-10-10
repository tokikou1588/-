using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.IBLL
{
    using EMS11.Model;

    public interface IUserInfoBLL : IBaseBLL<UserInfo>
    {
        UserInfo Login(string uname, string md5pwd);
    }
}
