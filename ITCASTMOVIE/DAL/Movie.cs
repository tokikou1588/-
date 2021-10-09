using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
   public  class Movie
    {

        #region 新增一个电影 + AddMovie
        public int AddMoive(MODEL.Movie model)
        {
            //准备SQL语句
            string sql = "insert into movie values(@name,@type,@area,@aid,@isQibing,0)";
            //给SQL语句准备参数
            SqlParameter[] paras = {
                                     new SqlParameter("@name",model.Name),
                                     new SqlParameter("@type",model.Type),
                                     new SqlParameter("@area",model.Country),
                                     new SqlParameter("@aid",model.Aid),
                                     new SqlParameter("@isQibing",model.IsQIBING)
                        
                                  };


            //执行SQL语句并返回一个int值
            return SQLHelper.ExecuteNonQuery(sql, paras);
        } 
        #endregion

        
        public List<MODEL.Movie> GetListBySearch(MODEL.Movie model, int PageIndex, int PageSize ,out int PageCount)
        {
            string sql = "select * from ( select  ROW_NUMBER() over (order by id) as rownum,* from movie where isDel = @isDel ";

            #region 各种拼接条件SQL语句
            //准备一个参数集合
            List<SqlParameter> parlist = new List<SqlParameter>();
            parlist.Add(new SqlParameter("@isDel", model.IsDel));
            //判断各种条件并拼接SQL语句
            if (!string.IsNullOrEmpty(model.Name))
            {
                sql += " and moviename like @name";
                parlist.Add(new SqlParameter("@name", "%" + model.Name + "%"));
            }
            if (!string.IsNullOrEmpty(model.PyName))
            {
                sql += " and pyname like @pyname";
                parlist.Add(new SqlParameter("@pyname", "%" + model.PyName + "%"));
            }
            if (!string.IsNullOrEmpty(model.Country))
            {
                sql += " and country like @country";
                parlist.Add(new SqlParameter("@country", "%" + model.Country + "%"));
            }
            if (model.IsQIBING)
            {
                sql += " and isQibing = @isQibing";
                parlist.Add(new SqlParameter("@isQibing", model.IsQIBING));
            }
            if (!string.IsNullOrEmpty(model.Type))
            {
                sql += " and type = @type";
                parlist.Add(new SqlParameter("@type", model.Type));
            }
            if (model.Aid != 0)
            {
                sql += " and aid = @aid";
                parlist.Add(new SqlParameter("@aid", model.Aid));
            } 
            #endregion

            sql += " ) as T where rownum between "+(((PageIndex-1)*PageSize)+1)+" and "+ PageIndex*PageSize;

           DataTable dt = SQLHelper.ExecuteDataTable(sql,parlist.ToArray());
           List<MODEL.Movie>list = Table2List(dt);
           PageCount = GetPageCount(model);
           return list;
        }

        public int GetPageCount(MODEL.Movie model)
        {
            string sql = " select count(*) as count  from  movie where isDel = @isDel ";

            #region 各种拼接条件SQL语句
            //准备一个参数集合
            List<SqlParameter> parlist = new List<SqlParameter>();
            parlist.Add(new SqlParameter("@isDel", model.IsDel));
            //判断各种条件并拼接SQL语句
            if (!string.IsNullOrEmpty(model.Name))
            {
                sql += " and moviename like @name";
                parlist.Add(new SqlParameter("@name", "%" + model.Name + "%"));
            }
            if (!string.IsNullOrEmpty(model.PyName))
            {
                sql += " and moviename like @pyname";
                parlist.Add(new SqlParameter("@pyname", "%" + model.PyName + "%"));
            }

            if (!string.IsNullOrEmpty(model.Country))
            {
                sql += " and country like @country";
                parlist.Add(new SqlParameter("@country", "%" + model.Country + "%"));
            }
            if (model.IsQIBING)
            {
                sql += " and isQibing = @isQibing";
                parlist.Add(new SqlParameter("@isQibing", model.IsQIBING));
            }
            if (!string.IsNullOrEmpty(model.Type))
            {
                sql += " and type = @type";
                parlist.Add(new SqlParameter("@type", model.Type));
            }
            if (model.Aid != 0)
            {
                sql += " and aid = @aid";
                parlist.Add(new SqlParameter("@aid", model.Aid));
            }
            #endregion


            SqlDataReader sdr = SQLHelper.ExecuteReader(sql,parlist.ToArray());

            string strcount ="";
            while (sdr.Read())
            { 
               strcount = sdr["count"].ToString();
            }
            return Convert.ToInt32(strcount);
        }

        #region a01.将数据表转换成泛型集合接口+ IList<MODEL.Movie> Table2List(DataTable dt)
        /// <summary>
        /// a01.将数据表转换成泛型集合接口
        /// </summary>
        /// <param name="dt">数据表对象</param>
        /// <returns>泛型集合接口</returns>
        public List<MODEL.Movie> Table2List(DataTable dt)
        {
            List<MODEL.Movie> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<MODEL.Movie>();
                MODEL.Movie model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new MODEL.Movie();
                    LoadEntityData(model, dr);
                    list.Add(model);
                }
                return list;
            }
            return null;
        }
        #endregion


        #region a04.加载实体数据(将行数据装入实体对象中)-void LoadEntityData(MODEL.BlogArticleCate model, DataRow dr)
        /// <summary>
        /// 加载实体数据(将行数据装入实体对象中)
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="dr">数据行</param>
        private void LoadEntityData(MODEL.Movie model, DataRow dr)
        {
            if (dr["id"].ToString() != "")
            {
                model.Id = int.Parse(dr["id"].ToString());
            }
            model.Name = dr["MovieName"].ToString();
            model.Type = dr["type"].ToString();
            model.PyName = dr["pyname"].ToString();
            model.Country = dr["country"].ToString();
            model.Aid = Convert.ToInt32(dr["aid"]);
            if (dr["isQIBING"].ToString() != "")
            {
                model.IsQIBING = bool.Parse(dr["isQIBING"].ToString());
            }

        }
        #endregion


        public int UpdateByDel(string ids,int isDel)
        {
            string sql = "Update Movie set isDel =@isDel where id in ("+ids+")";
            SqlParameter p = new SqlParameter("@isDel",isDel);
            return SQLHelper.ExecuteNonQuery(sql, p);
           
        }

        public int UpdateMovie(MODEL.Movie model)
        {
            string sql = "update Movie set MovieName =@name,type=@type,country=@area,aid=@aid,isQibing=@isQibing where id= @id";
            SqlParameter[] paras = {
                                   new SqlParameter("@name",model.Name),
                                   new SqlParameter("@type",model.Type),
                                     new SqlParameter("@area",model.Country),
                                   new SqlParameter("@aid",model.Aid),
                                     new SqlParameter("@isQibing",model.IsQIBING),
                                   new SqlParameter("@id",model.Id)
                                   };
            return SQLHelper.ExecuteNonQuery(sql, paras);
            
        }
    }
}
