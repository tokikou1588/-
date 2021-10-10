using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.BLL
{
    using EMS11.IBLL;
    using EMS11.Model;

    public class UserInfoBLL : BaseBLL<UserInfo>, IUserInfoBLL
    {
        public UserInfoBLL(EMS11.IDal.IBaseDal<UserInfo> dal)
        {
            base.dal = dal;
        }

        public UserInfo Login(string uname, string md5pwd)
        {
            return base.WhereByCondition(c => c.u_name == uname && c.u_pwd == md5pwd).FirstOrDefault();
        }
    }
}
