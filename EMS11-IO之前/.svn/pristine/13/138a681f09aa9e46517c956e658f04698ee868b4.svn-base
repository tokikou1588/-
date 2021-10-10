using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.AbsFactory
{
    using EMS11.IBLL;
    using System.Reflection;

    /// <summary>
    /// 负责创建具体的业务工厂，并且约定当前业务工厂中实例化的具体实现类的方法
    /// </summary>
    public abstract class AbsFactor
    {
        /// <summary>
        /// 负责创建具体的业务工厂实例
        /// </summary>
        public static AbsFactor CreateBllFactory()
        {
            //AbsFactor absbll = new Factor();
            //通过反射创建具体的业务实现工厂以AbsFactor 返回

            //1.0 获取当前要反射的具体工厂的命名空间
            string nspace = System.Configuration.ConfigurationManager.AppSettings["BLLFactory"];

            //2.0 根据命名空间获取当前运行的程序集
            Assembly ass = Assembly.Load(nspace);

            //3.0 根据ass创建类Factor 的类实体
            object obj = ass.CreateInstance(nspace + ".Factor");

            return obj as AbsFactor;
        }

        public abstract IUserInfoBLL Create_UserInfoBll_Instance();

        public abstract IProductBLL Create_ProductBLL_Instance();


        public abstract INewsBLL Create_NewsBLL_Instance();

        public abstract IMenusBLL Create_MenusBLL_Instance();


        public abstract IfeedbackBLL Create_feedbackBLL_Instance();



        public abstract IContentsBLL Create_ContentsBLL_Instance();



        public abstract ICategoryBLL Create_CategoryBLL_Instance();

    }
}
