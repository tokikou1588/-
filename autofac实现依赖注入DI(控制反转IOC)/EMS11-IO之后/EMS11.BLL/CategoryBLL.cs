using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.BLL
{
    using EMS11.IBLL;
    using EMS11.IDal;
    using EMS11.Model;

    public class CategoryBLL : BaseBLL<Category>, ICategoryBLL
    {
        public CategoryBLL(IBaseDal<Category> dal)
        {
            base.dal = dal;
        }
    }
}
