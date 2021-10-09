using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
 public   class Actor
    {

     DAL.Actor dal = new DAL.Actor();
     
     public List<MODEL.Actor> GetAllList(int isDel)
     {

         return dal.GetAllList(isDel); ;
     }

     public bool Add(MODEL.Actor model)
     {


         return dal.Add(model) > 0;
     }

     public int UpadateIsDel(MODEL.Actor model,int type)
     {
         return dal.UpdateActor(model,type);
     }
    }
}
