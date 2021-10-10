using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassesManager
    {
        DAL.ClassesService cs = new DAL.ClassesService();

        #region 获取所有班级列表信息  +List<MODEL.Classes> GetAllClassesList(bool isDel)
        /// <summary>
        /// 获取所有班级列表信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Classes> GetAllClassesList(bool isDel)
        {
            return cs.GetAllClassesList(isDel);
        } 
        #endregion
    }
}
