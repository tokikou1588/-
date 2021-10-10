using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AreasManager
    {
        DAL.AreasService das = new DAL.AreasService();

        #region 获取所有地区信息 + List<MODEL.Areas> GetAllAraesList(bool isDel)
        /// <summary>
        /// 获取所有地区信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Areas> GetAllAraesList(bool isDel)
        {
            return das.GetAllAraesList(isDel);
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
            return das.GetArea(id);
        } 
        #endregion
    }
}
