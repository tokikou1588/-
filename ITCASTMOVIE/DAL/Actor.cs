using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
  public  class Actor
    {

      public List<MODEL.Actor> GetAllList(int isDel)
      {
          //准备SQL语句
          string sql = "select * from Actor where isdel = @isDel";
          //sql参数
          SqlParameter p = new SqlParameter("@isDel",isDel);
          //调用sqlhelper方法 并接受返回回来的数据
          DataTable dt = SQLHelper.ExecuteDataTable(sql,p);
          //声明一个列表
          List<MODEL.Actor> list = null;
          //判断是否返回了数据 如果没返回则不做下一步了
          if (dt.Rows.Count > 0)
          {
              //new list 给它在内存开辟空间
              list = new List<MODEL.Actor>();
              //声明一个对象
              MODEL.Actor model = null;
              //遍历返回的数据
              foreach (DataRow dr in dt.Rows)
              {
                  //给对象开辟空间
                  model = new MODEL.Actor();
                  //将每条数据转成model对象
                  DataRowToModel(model,dr);
                  //列表加上对象
                  list.Add(model);
              }
          }
          //返回列表
          return list;
      }

      #region Add方法 将model对象插入到数据库里 +Add(MODEL.Actor model)

      public int Add(MODEL.Actor model)
      {

          string sql = "insert into Actor values(@name,@age,@isDel,@lv)";
          SqlParameter[] paras = { 
                                 new SqlParameter("@name",model.Name),
                                 new SqlParameter("@age",model.Age),
                                 new SqlParameter("@isDel",model.IsDel),
                                 new SqlParameter("@lv",model.Lv)
                                 };
          return SQLHelper.ExecuteNonQuery(sql, paras);
      } 
      #endregion



      //updata方法 会根据用户传来的参数来进行修改或者软删除！
      public int UpdateActor(MODEL.Actor model, int type)
      {
          //如果Type大于0 则执行软删除操作 为1则到“回收站” 为2则“彻底删除”
          if (type > 0)
          {
              string sql = "update Actor set isDel =@isDel where id = @id";
              SqlParameter[] paras = { 
                                     new SqlParameter("@isDel",type),
                                     new SqlParameter("@id",model.Id)
                                     };
              return SQLHelper.ExecuteNonQuery(sql, paras);
          }
              //如果type 小于0 则执行修改操作
          else if(type < 0)
          {
              string sql = "update Actor set name =@name,age=@age,lv=@lv where id = @id";
              SqlParameter[] paras = { 
                                      new SqlParameter("@name",model.Name),
                                      new SqlParameter("@age",model.Age),
                                      new SqlParameter("@lv",model.Lv),
                                      new SqlParameter("@id",model.Id)
                                     };

              return SQLHelper.ExecuteNonQuery(sql,paras);
              
          }

              //如果等于0 则执行软还原操作
          else
          {
              string sql = "update Actor set isDel =@isDel where id = @id";
              SqlParameter[] paras = { 
                                     new SqlParameter("@isDel",type),
                                     new SqlParameter("@id",model.Id)
                                     };
              return SQLHelper.ExecuteNonQuery(sql, paras);
          }
        
      }

     // a04.加载实体数据(将行数据装入实体对象中)-void LoadEntityData(MODEL.BlogArticleCate model, DataRow dr)
      /// <summary>
      /// 加载实体数据(将行数据装入实体对象中)
      /// </summary>
      /// <param name="model">实体对象</param>
      /// <param name="dr">数据行</param>
      private void DataRowToModel(MODEL.Actor model, DataRow dr)
      {
          if (dr["id"].ToString() != "")
          {
              model.Id = int.Parse(dr["id"].ToString());
          }
          model.Name = dr["Name"].ToString();
          if (dr["Age"].ToString() != "")
          {
              model.Age = int.Parse(dr["Age"].ToString());
          }
          if (dr["IsDel"].ToString() != "")
          {
              model.IsDel = int.Parse(dr["IsDel"].ToString());
          }
          if (dr["Lv"].ToString() != "")
          {
              model.Lv = int.Parse(dr["Lv"].ToString());
          }

      }
    }
}
