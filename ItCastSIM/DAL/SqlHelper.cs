using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class SqlHelper
    {
        /// <summary>
        /// 使用配置文件创建连接字符串
        /// </summary>
        readonly static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString; //“DAL.SqlHelper”的类型初始值设定项引发异常--配置文件错误，或者调用配置文件错误

        #region 返回结果集第一行第一列  + static int ExcuteScalar(string sql, params SqlParameter[] ps)
        /// <summary>
        /// 返回结果集第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static object ExcuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddRange(ps);
                return comm.ExecuteScalar();
            }
        } 
        #endregion

        #region  获取结果集  +static DataTable ExcuteTable(string sql, params SqlParameter[] ps)
        /// <summary>
        /// 获取结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static DataTable ExcuteTable(string sql, params SqlParameter[] ps)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connStr); //封装了三大对象
            da.SelectCommand.Parameters.AddRange(ps);
            DataTable dt = new DataTable();
            da.Fill(dt); //也是调用了读取器一行一行读取到表中的
            return dt;
        } 
        #endregion

        #region 执行增加，删除和修改  +static int ExcuteNonQuery(string sql, params SqlParameter[] ps)
        /// <summary>
        /// 执行增加，删除和修改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                com.Parameters.AddRange(ps);
                return com.ExecuteNonQuery();
            }
        } 
        #endregion
    }
}
