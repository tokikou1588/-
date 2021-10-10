using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.BLL
{
    using EMS11.IBLL;
    using EMS11.Model;

    public class MenusBLL : BaseBLL<Menus>,IMenusBLL
    {
        public MenusBLL(EMS11.IDal.IBaseDal<Menus> dal)
        {
            base.dal = dal;
        }
    }
}
