using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonManager
    {
        DAL.PersonService ps = new DAL.PersonService();

        #region 登录判断  +MODEL.Person Login(string name, string pwd)
        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public MODEL.Person Login(string name)
        {
            return ps.Login(name);
        } 
        #endregion

        #region 获取所有人员信息  +List<MODEL.Person> GetAllPersonList(bool isDel)
        /// <summary>
        /// 获取所有人员信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Person> GetAllPersonList(bool isDel)
        {
            return ps.GetAllPersonList(isDel);
        } 
        #endregion

        #region 删除人员信息  +bool DeletePerson(int id)
        /// <summary>
        ///删除人员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePerson(int id)
        {
            return ps.DeletePerson(id);
        } 
        #endregion

        #region 新增操作  + bool AddNewPerson(MODEL.Person newP)
        /// <summary>
        /// 新增操作
        /// </summary>
        /// <param name="newP"></param>
        /// <returns></returns>
        public bool AddNewPerson(MODEL.Person newP)
        {
            return ps.AddNewPerson(newP);
        } 
        #endregion

        #region 修改用户信息  + int UpdatePerson(MODEL.Person upPer)
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="upPer"></param>
        /// <returns></returns>
        public bool UpdatePerson(MODEL.Person upPer)
        {
            return ps.UpdatePerson(upPer)==1;
        } 
        #endregion
    }
}
