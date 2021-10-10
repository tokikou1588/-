using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.BLLFactory
{
    using EMS11.IBLL;
    using EMS11.BLL;
    using EMS11.AbsFactory;

    /// <summary>
    /// 负责创建业务层的具体实现
    /// </summary>
    public class Factor : AbsFactor
    {
        public override IUserInfoBLL Create_UserInfoBll_Instance()
        {
            //这里可以使用反射的方式创建
            return new UserInfoBLL();
        }

        public override IProductBLL Create_ProductBLL_Instance()
        {
            return new ProductBLL();
        }

        public override INewsBLL Create_NewsBLL_Instance()
        {
            return new NewsBLL();
        }

        public override IMenusBLL Create_MenusBLL_Instance()
        {
            return new MenusBLL();
        }

        public override IfeedbackBLL Create_feedbackBLL_Instance()
        {
            return new feedbackBLL();
        }


        public override IContentsBLL Create_ContentsBLL_Instance()
        {
            return new ContentsBLL();
        }


        public override ICategoryBLL Create_CategoryBLL_Instance()
        {
            return new CategoryBLL();
        }
    }
}
