using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PersonService
    {
        #region 登录判断  +MODEL.Person Login(string name, string pwd)
        /// <summary>
        /// 登录判断
        /// 传入登录名，根据登录名获取对应的行记录，将行记录转换为对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public MODEL.Person Login(string name)
        {
            string sql = "select person.*,cname from person inner join classes on Person.PCID=Classes.CID  where ploginname=@name and pisdel=@isDel";
            SqlParameter[] ps ={
                                  new SqlParameter("name",name),
                                  new SqlParameter("isDel",false)
                              };
            //1.如果是得到增加删除和修改以及结果集的第一行第一列值那么就使用创建连接对象，命令对象，调用命令对象的方法
            //2.如果是想得到结果集多行多列(多个值)，一般不会使用SqlDataReader,而使用SqlDataAdapter
            DataTable dt = SqlHelper.ExcuteTable(sql, ps); //根据唯一约束的原理，表中应该只有一条记录
            MODEL.Person person = null;
            if (dt.Rows.Count > 0)//判断有没有返回记录
            {
                person = new MODEL.Person();
                DataRowToPerson(dt.Rows[0], person); //person是引用类型，方法对其进行修改， 原始值也会变化
            }
            return person;
        }
        #endregion

        #region 获取所有人员信息  +List<MODEL.Person> GetAllPersonList(bool isDel)
        /// <summary>
        ///  获取所有人员信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Person> GetAllPersonList(bool isDel)
        {
            string sql = "select person.*,cname from person inner join classes on Person.PCID=Classes.CID  where  pisdel=@isDel and cisdel=@isdel";
            SqlParameter p = new SqlParameter("isDel", isDel);
            DataTable dt = SqlHelper.ExcuteTable(sql, p);
            List<MODEL.Person> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.Person>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.Person pp = new MODEL.Person();
                    DataRowToPerson(row, pp);
                    lists.Add(pp);
                }
            }
            return lists;
        }
        #endregion

        #region 将人员结果集表中的行转换为对象  +void DataRowToPerson(DataRow row, MODEL.Person person)
        /// <summary>
        /// 将人员结果集表中的行转换为对象
        /// </summary>
        /// <param name="row"></param>
        /// <param name="person"></param>
        private void DataRowToPerson(DataRow row, MODEL.Person person)
        {
            person.PID = Convert.ToInt32(row[0]);
            person.PCID = Convert.ToInt32(row[1]);
            person.PType = Convert.ToInt32(row[2]);
            person.PLoginName = row[3].ToString();
            person.PCName = row[4].ToString();
            person.PPYName = row[5].ToString();
            person.PPwd = row[6].ToString();
            person.PGender = Convert.ToBoolean(row[7]);
            if (!(row[8] is DBNull) && !(string.IsNullOrEmpty(row[8].ToString())))
            {
                person.PEmail = row[8].ToString();
            }
            person.PAreas = row[9].ToString();
            person.PIsDel = Convert.ToBoolean(row[10]);
            person.PAddTime = Convert.ToDateTime(row[11]);
            person.Cname = row[12].ToString(); //得到班级信息
        }
        #endregion

        #region 删除人员信息  +bool DeletePerson(int id)
        /// <summary>
        ///删除人员信息,不是真正的删除而是修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePerson(int id)
        {
            string sql = "update person set pisdel=1 where pid=@id";
            SqlParameter p = new SqlParameter("id", id);
            return SqlHelper.ExcuteNonQuery(sql, p) == 1;
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
            SqlParameter pp = new SqlParameter("aa", null);
            string sql = "insert into person(pcid,ptype,ploginname,pcname,ppyname,ppwd,pgender,pemail,pareas) values(@pcid,@ptype,@ploginname,@pcname,@ppyname,@ppwd,@pgender,@pemail,@pareas)";
            SqlParameter[] ps = { 
                                new SqlParameter("pcid",newP.PCID),
                                new SqlParameter("ptype",newP.PType),
                                new SqlParameter("ploginname",newP.PLoginName),
                                new SqlParameter("pcname",newP.PCName),
                                new SqlParameter("ppyname",string.IsNullOrEmpty(newP.PPYName)?DBNull.Value:(object)newP.PPYName), //C#的null与数据库的null不是一样的，数据库中null值在c#里面是DBNull
                                new SqlParameter("ppwd",newP.PPwd),
                                new SqlParameter("pgender",newP.PGender),
                                new SqlParameter("pemail",string.IsNullOrEmpty(newP.PEmail)?DBNull.Value:(object)newP.PEmail),
                                new SqlParameter("pareas",string.IsNullOrEmpty(newP.PAreas)?DBNull.Value:(object)newP.PAreas)
                                };
            return SqlHelper.ExcuteNonQuery(sql, ps) == 1;
        }
        #endregion

        #region 修改用户信息  + int UpdatePerson(MODEL.Person upPer)
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="upPer"></param>
        /// <returns></returns>
        public int UpdatePerson(MODEL.Person upPer)
        {
            string sql = "update person set pcid=@pcid,ptype=@ptype,ploginname=@ploginname,pcname=@pcname,ppyname=@ppyname,ppwd=@ppwd,pgender=@pgender,pemail=@pemail,pareas=@pareas where pid=@pid";
            SqlParameter[] ps = { 
                                    new SqlParameter("pid",upPer.PID),
                                   new SqlParameter("pcid",upPer.PCID),
                                  new SqlParameter("ptype",upPer.PType),
                                 new SqlParameter("ploginname",upPer.PLoginName),
                                 new SqlParameter("pcname",upPer.PCName),
                                  new SqlParameter("ppyname",string.IsNullOrEmpty(upPer.PPYName)?DBNull.Value:(object)upPer.PPYName), //C#的null与数据库的null不是一样的，数据库中null值在c#里面是DBNull
                                  new SqlParameter("ppwd",upPer.PPwd),
                                  new SqlParameter("pgender",upPer.PGender),
                                  new SqlParameter("pemail",string.IsNullOrEmpty(upPer.PEmail)?DBNull.Value:(object)upPer.PEmail),
                                   new SqlParameter("pareas",string.IsNullOrEmpty(upPer.PAreas)?DBNull.Value:(object)upPer.PAreas)
                                };
            return SqlHelper.ExcuteNonQuery(sql, ps);
        }
        #endregion
    }
}
