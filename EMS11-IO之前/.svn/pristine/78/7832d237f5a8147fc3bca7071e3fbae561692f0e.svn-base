

namespace EMS11.DalFactory
{
    using EMS11.Dal;
    using EMS11.IDal;

    /// <summary>
    /// 负责创建Dal具体实现者以IDal接口返回，在后面大项目中会被spring.net来替换
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Factor<TEntity> where TEntity : class
    {
        /// <summary>
        /// 负责创建BaseDal<>泛型类以IBaseDal<> 泛型接口返回
        /// </summary>
        /// <returns></returns>
        public static IBaseDal<TEntity> CreateInstance()
        {
            //TODO:此处简单一点，直接new具体的实现，其实应该通过反射+ web.config配置来动态创建

            return new BaseDal<TEntity>();
        }
    }
}
