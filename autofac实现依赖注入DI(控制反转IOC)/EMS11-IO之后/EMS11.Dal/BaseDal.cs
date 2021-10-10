using System;
using System.Collections.Generic;
using System.Linq;

namespace EMS11.Dal
{
    using EMS11.IDal;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq.Expressions;
    using System.Runtime.Remoting.Messaging;

    public class BaseDal<TEntity> : IBaseDal<TEntity> where TEntity : class
    {
        #region 0.0 私有成员定义
        //由于：在一个action中要同时操作多个表的数据，而现在是每个表会对应一个EF上下文容器，所以会导致
        //打开多次db链接，应该确保当前http请求处理线程只有唯一的一份EF上下文容器，改造如下

        //BaseDBContext db = new BaseDBContext();

        public BaseDBContext db
        {
            get
            {
                //CallContext 负责缓存当前线程中的EF容器对象
                object efContext = System.Runtime.Remoting.Messaging.CallContext.GetData(typeof(BaseDBContext).FullName);
                //如果EF容器没有被缓存则要创建，将创建好的实体对象存入CallContext中管理
                if (efContext == null)
                {
                    BaseDBContext _db = new BaseDBContext();
                    System.Runtime.Remoting.Messaging.CallContext.SetData(typeof(BaseDBContext).FullName, _db);
                    efContext = _db;
                }

                //将EF上下文容器返回
                return efContext as BaseDBContext;
            }
        }

        DbSet<TEntity> _dbset;
        #endregion

        #region 1.0 在构造函数中根据传入的具体实体类名称 实例化DbSet<TEntity>
        public BaseDal()
        {
            _dbset = db.Set<TEntity>();
        }
        #endregion

        #region 2.0 将DbSet以属性的形式封装，将来在Bll层也要定义一份相同的属性，并且调用此属性
        public DbSet<TEntity> DbSet
        {
            get
            {
                return _dbset;
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
            return _dbset.ToList();
        }

        /// <summary>
        /// 根据条件查询对应表的符合条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> WhereByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).ToList();
        }

        /// <summary>
        /// 连表查询
        /// </summary>
        /// <param name="predicate">主表TEntity 的查询条件</param>
        /// <param name="IncludeTables">与主表TEntity 要链接的表数组</param>
        /// <returns></returns>
        public List<TEntity> WhereJoin(Expression<Func<TEntity, bool>> predicate, string[] IncludeTables)
        {
            DbQuery<TEntity> reslist = _dbset;
            if (IncludeTables != null && IncludeTables.Length > 0)
            {
                foreach (var tbName in IncludeTables)
                {
                    reslist = reslist.Include(tbName);
                }
            }

            return reslist.Where(predicate).ToList();
        }

        #endregion

        #region 4.0 新增

        public void Add(TEntity model)
        {
            _dbset.Add(model);
        }


        #endregion

        #region 5.0 编辑

        /// <summary>
        /// 负责自定义实体和指定了具体要更新的字段
        /// </summary>
        public void Update(TEntity model, string[] propertys)
        {
            if (propertys == null || propertys.Length == 0)
            {
                throw new Exception("当前更新的实体必须至少指定一个字段名称");
            }

            //1.0 关闭EF的 实体验证检查
            db.Configuration.ValidateOnSaveEnabled = false;

            //2.0 将实体手工追加到EF容器中
            DbEntityEntry entry = db.Entry(model);
            //3.0 将EF容器中当前实体的代理类状态修改成Unchanged
            entry.State = System.Data.EntityState.Unchanged;
            //4.0 遍历用户传入的属性数值，将代理类中的属性对应的IsModified设置成true
            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }
        }

        #endregion

        #region 6.0 删除

        public void Remove(TEntity model, bool isAddedEFContext)
        {
            //表示当前model未追加到EF上下文容器
            if (isAddedEFContext == false)
            {
                _dbset.Attach(model);
            }
            //将EF容器中当前实体对于的代理类状态修改成deleted
            _dbset.Remove(model);
        }

        #endregion

        #region 7.0 统一遍历当前EF容器执行保存操作

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        #endregion

    }
}
