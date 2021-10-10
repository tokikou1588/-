using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.BLL
{
    using EMS11.IDal;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using EMS11.IBLL;

    public class BaseBLL<TEntity> : IBaseBLL<TEntity> where TEntity : class
    {
        //1.0 利用数据访问层工厂 实例化Dal层的具体实现，以那接口的形式放回
        //protected IBaseDal<TEntity> dal = Factor<TEntity>.CreateInstance();
        protected IBaseDal<TEntity> dal;
        ///// <summary>
        ///// 构造函数是给autofac ioc工具来进行调用
        ///// </summary>
        ///// <param name="dal1">在运行期间，dal1实际上是IBaseDal<TEntity> 的具体实现类（BaseDal<TEntity>）</param>
        //public BaseBLL(IBaseDal<TEntity> dal1)
        //{
        //    this.dal = dal1;
        //}


        #region 2.0 将DbSet以属性的形式封装，将来在Bll层也要定义一份相同的属性，并且调用此属性
        public DbSet<TEntity> DbSet
        {
            get
            {
                return dal.DbSet;
            }
        }
        #endregion

        #region 3.0 查询

        /// <summary>
        /// 查找对应表的所有数据
        /// </summary>
        /// <returns></returns>
        public List<TEntity> WhereAll()
        {
            return dal.WhereAll();
        }

        /// <summary>
        /// 根据条件查询对应表的符合条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> WhereByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return dal.WhereByCondition(predicate);
        }

        /// <summary>
        /// 连表查询
        /// </summary>
        /// <param name="predicate">主表TEntity 的查询条件</param>
        /// <param name="IncludeTables">与主表TEntity 要链接的表数组</param>
        /// <returns></returns>
        public List<TEntity> WhereJoin(Expression<Func<TEntity, bool>> predicate, string[] IncludeTables)
        {
            return dal.WhereJoin(predicate, IncludeTables);
        }

        #endregion

        #region 4.0 新增

        public void Add(TEntity model)
        {
            dal.Add(model);
        }


        #endregion

        #region 5.0 编辑

        /// <summary>
        /// 负责自定义实体和指定了具体要更新的字段
        /// </summary>
        public void Update(TEntity model, string[] propertys)
        {
            dal.Update(model, propertys);
        }

        #endregion

        #region 6.0 删除

        public void Remove(TEntity model, bool isAddedEFContext)
        {
            dal.Remove(model, isAddedEFContext);
        }

        #endregion

        #region 7.0 统一遍历当前EF容器执行保存操作

        public int SaveChanges()
        {
            return dal.SaveChanges();
        }

        #endregion

    }
}
