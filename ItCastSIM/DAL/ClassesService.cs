using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ClassesService
    {
        #region 获取所有班级列表信息  +List<MODEL.Classes> GetAllClassesList(bool isDel)
        /// <summary>
        /// 获取所有班级列表信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Classes> GetAllClassesList(bool isDel)
        {
            string sql = "select * from classes where cisdel=@isdel";
            SqlParameter p = new SqlParameter("isdel",isDel);
            DataTable dt = SqlHelper.ExcuteTable(sql,p);
            List<MODEL.Classes> lists = null;
            if(dt.Rows.Count>0)
            {
                lists = new List<MODEL.Classes>();
                foreach(DataRow row in dt.Rows)
                {
                    MODEL.Classes c = new MODEL.Classes();
                    DataRowToClasses(row,c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 将班级行数据转换为班级类对象  -void DataRowToClasses(DataRow row, MODEL.Classes cl)
        /// <summary>
        /// 将班级行数据转换为班级类对象
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cl"></param>
        void DataRowToClasses(DataRow row, MODEL.Classes cl)
        {
            cl.CID = Convert.ToInt32(row[0]);
            cl.CName = row[1].ToString();
            cl.CCount = Convert.ToInt32(row[2]);
            cl.CImg = row[3].ToString();
            cl.CIsDel = Convert.ToBoolean(row[4]);
            cl.CAddTime = Convert.ToDateTime(row[5]);
        } 
        #endregion
    }
}
