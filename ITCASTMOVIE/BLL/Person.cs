using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Person
    {
        DAL.Person dal = new DAL.Person();

        public MODEL.Person Login(MODEL.Person model)
        {
            return dal.Login(model);
        }

        public bool AddPerson(MODEL.Person model)
        {
            return dal.AddPerson(model)>0;
        }
    }
}
