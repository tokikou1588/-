using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Movie
    {
       //准备一个DAL对象
       DAL.Movie dal = new DAL.Movie();
       public bool AddMovie(MODEL.Movie model)
       {


           return dal.AddMoive(model) > 0;
       }

       public List<MODEL.Movie> GetListBySearch(MODEL.Movie model,int PageIndex,int PageSize,out int PageCount)
       {
           if(model ==null)
           { 
            return dal.GetListBySearch(new MODEL.Movie(),PageIndex,PageSize, out PageCount);
           }
           return dal.GetListBySearch(model,PageIndex,PageSize,out PageCount);
       }

       public int UpdateByDel(string ids,int isDel)
       {
           return dal.UpdateByDel(ids,isDel);
       }

       public bool UpdateMovie(MODEL.Movie model)
       {
           return dal.UpdateMovie(model)>0;
       }
       
    }
}
