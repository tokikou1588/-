using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AreasService
    {
        #region 获取所有地区信息 + List<MODEL.Areas> GetAllAraesList(bool isDel)
        /// <summary>
        /// 获取所有地区信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Areas> GetAllAraesList(bool isDel)
        {
            string sql = "select AID,AName,APid,ASort,AAddTime,ADelFlag from Areas where ADelFlag=@isdel ";
            SqlParameter p = new SqlParameter("isdel",isDel);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL.Areas> lists = null;
            if(dt.Rows.Count>0)
            {
                lists = new List<MODEL.Areas>();
                foreach(DataRow row in dt.Rows)
                {
                    MODEL.Areas a = new MODEL.Areas();
                    DataRowToAraes(row,a);
                    lists.Add(a);
                }
            }
            return lists;
        }
        #endregion

        #region 将班级表行数据转换为班级实体类对象  -void DataRowToAraes(DataRow row, MODEL.Areas area)
        /// <summary>
        /// 将班级表行数据转换为班级实体类对象
        /// </summary>
        /// <param name="row"></param>
        /// <param name="area"></param>
        void DataRowToAraes(DataRow row, MODEL.Areas area)
        {
            area.AID = Convert.ToInt32(row[0]);
            area.AName = row[1].ToString();
            area.APid = Convert.ToInt32(row[2]);
            area.ASort = Convert.ToInt32(row[3]);
            area.AAddTime = Convert.ToDateTime(row[4]);
            area.ADelFlag = Convert.ToBoolean(row[5]);
        } 
        #endregion

        #region 通过地区ID获取地区字符串值  + string GetArea(string id)
        /// <summary>
        /// 通过地区ID获取地区字符串值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetArea(string id)
        {
            string sql = "select AName from Areas where AID=@id";
            SqlParameter p = new SqlParameter("id",id);
            return SqlHelper.ExcuteScalar(sql, p).ToString();
        }
        #endregion
    }
}
