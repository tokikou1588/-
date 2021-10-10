

namespace EMS11.Dal
{
    using System.Data.Entity;

    /// <summary>
    /// EF上下文容器的子类，供BaseDal类来使用
    /// </summary>
    public class BaseDBContext : DbContext
    {
        public BaseDBContext()
            : base("name=kyprintEntities")
        {
        }
    }
}
