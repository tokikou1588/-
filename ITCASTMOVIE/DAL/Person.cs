using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Person
    {

        public MODEL.Person Login( MODEL.Person model)
        {
            string sql = "select * from Person where LoginUserName =@LoginUserName and LoginPassword = @LoginPassword";
            SqlParameter[] paras ={
                                    new SqlParameter("@LoginUserName",model.LoginUserName),
                                    new SqlParameter("@LoginPassword",model.LoginPassword)
                                  };
            SqlDataReader dr = SQLHelper.ExecuteReader(sql, paras);
            while (dr.Read())
            {
                model.ID = Convert.ToInt32(dr["id"]);
                //model.LoginUserName = dr["LoginUserName"].ToString();
                //model.LoginPassword = dr["LoginPassword"].ToString();
                model.NickName = ToValue(dr, "NickName").ToString();
                model.Gender = Convert.ToBoolean(dr["Gender"]);
                model.IsDel = Convert.ToInt32(dr["isDel"]);
                model.Birthday = (DateTime?)ToValue(dr,"Birthday");
                model.CellPhone = ToValue(dr, "CellPhone").ToString();
              //  model.Email = ToValue(dr, "Email").ToString();
            }

            return model;
        }

        public object ToValue(SqlDataReader reader, string columnName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return null;
            }
            else
            {
                return reader[columnName];
            }
        }

        public int AddPerson(MODEL.Person model)
        {
            string sql = "insert into Person values(@name,@pwd,@nickname,@birthday,@gender,@cellphone,@email,0) ";
            SqlParameter[] paras = {
                                      new SqlParameter("@name",model.LoginUserName),
                                      new SqlParameter("@pwd",model.LoginPassword),
                                       new SqlParameter("@nickname",model.NickName),
                                       new SqlParameter("@birthday",model.Birthday),
                                       new SqlParameter("@gender",model.Gender),
                                      new SqlParameter("@cellphone",12345678),
                                       new SqlParameter("@email",model.Email)
                                   };
            return SQLHelper.ExecuteNonQuery(sql, paras);

         
        }
    }

 

}
