using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.BLL
{
    using EMS11.IBLL;
    using EMS11.Model;

    public class NewsBLL : BaseBLL<News>,INewsBLL
    {
        public NewsBLL(EMS11.IDal.IBaseDal<News> dal)
        {
            base.dal = dal;
        }
    }
}
