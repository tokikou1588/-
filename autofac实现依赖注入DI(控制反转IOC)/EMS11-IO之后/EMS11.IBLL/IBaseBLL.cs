using System;
using System.Collections.Generic;


namespace EMS11.IBLL
{
    using System.Data.Entity;
    using System.Linq.Expressions;

    public interface IBaseBLL<TEntity> where TEntity : class
    {
        #region 2.0 将DbSet以属性的形式封装，将来在Bll层也要定义一份相同的属性，并且调用此属性
        DbSet<TEntity> DbSet { get; }
      
        #endregion

        #region 3.0 查询

        /// <summary>
        /// 查找对应表的所有数据
        /// </summary>
        /// <returns></returns>
        List<TEntity> WhereAll();
   

        /// <summary>
        /// 根据条件查询对应表的符合条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
         List<TEntity> WhereByCondition(Expression<Func<TEntity, bool>> predicate);
       

        /// <summary>
        /// 连表查询
        /// </summary>
        /// <param name="predicate">主表TEntity 的查询条件</param>
        /// <param name="IncludeTables">与主表TEntity 要链接的表数组</param>
        /// <returns></returns>
         List<TEntity> WhereJoin(Expression<Func<TEntity, bool>> predicate, string[] IncludeTables);
      

        #endregion

        #region 4.0 新增

         void Add(TEntity model);
      


        #endregion

        #region 5.0 编辑

        /// <summary>
        /// 负责自定义实体和指定了具体要更新的字段
        /// </summary>
         void Update(TEntity model, string[] propertys);
     

        #endregion

        #region 6.0 删除

         void Remove(TEntity model, bool isAddedEFContext);
      

        #endregion

        #region 7.0 统一遍历当前EF容器执行保存操作

         int SaveChanges();
      

        #endregion
    }
}
