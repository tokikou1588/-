using System.Data.SqlClient;
using System;
using System.Data;

namespace DAL
{
    internal static class SQLHelper
    {

        #region 读取配置文件里的连接字符串
        /// <summary>
        /// 读取配置文件获得连接字符串
        /// </summary>
        public static readonly string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString; 
        #endregion

        #region 01执行SQL语句返一个+DataTable ExecuteDataTable(string sql, params SqlParameter[] paras)
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数数组</param>
        /// <returns>返回一个DataTable</returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] paras)
        {
            //创建数据库连接对象
            SqlConnection conn = new SqlConnection(connStr);
            //准备一个适配器并传入sql语句与连接对象
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            //准备一个datatable
            DataTable table = new DataTable();
            //传入参数
            adapter.SelectCommand.Parameters.AddRange(paras);
            //填充datatable
            adapter.Fill(table);
            //返回table
            return table;
        }
        #endregion

        #region 02执行SQL语句返回一个对象 +object ExecuteScalar(string sql, params SqlParameter[] paras)
        /// <summary>
        /// 执行SQL命令返回结果集的首行首列的值
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数数组</param>
        /// <returns>返回一个对象</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                //创建命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //判断用户是否传入了可变参数 如果传入了 则添加参数到命令对象
                if (paras.Length > 0)
                {
                    cmd.Parameters.AddRange(paras);
                }
                //打开连接通道
                conn.Open();
                //返回结果集的首行首列
                return cmd.ExecuteScalar();
            }
        }
        #endregion

        #region 03执行SQL语句返回受影响的行数+int ExecuteNonQuery(string sql, params SqlParameter[] paras)
        /// <summary>
        /// 执行SQL语句返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //判断参数数组是否传值
                if (paras.Length > 0)
                {
                    cmd.Parameters.AddRange(paras);
                }
                //打开通道
                conn.Open();
                //返回受影响的行数
                return cmd.ExecuteNonQuery();
            }
        } 
        #endregion

        #region 04执行sql命令 返回1个读取器 + SqlDataReader ExecuteReader(string sql, params SqlParameter[] paras)
        /// <summary>
        ///  执行sql命令 返回1个读取器
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] paras)
        {
            //声明连接通道对象
            SqlConnection conn = null;
            try
            {
                //创建连接通道对象
                conn = new SqlConnection(connStr);
                //打开连接通道
                conn.Open();
                //创建命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //判断用户是否传入可变参数
                if (paras.Length > 0)
                {
                    cmd.Parameters.AddRange(paras);
                }
                else
                {
                    throw new Exception("参数不能为0个");
                }
                
                
                //返回读取器
                return cmd.ExecuteReader(CommandBehavior.CloseConnection); //CommandBehavior.CloseConnection关闭SqlDataReader的时候 连接通道也会一起关闭
            }
            catch (Exception ex)//异常处理
            {
                if (conn.State == ConnectionState.Open)//如果连接通道时打开状态 则关闭连接通道
                {
                    conn.Close();
                }
                throw ex;
            }
        }
        #endregion

    }


}
