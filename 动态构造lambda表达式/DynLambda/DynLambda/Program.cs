using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynLambda
{
    using System.Linq.Expressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<Pig> list = new List<Pig>() { 
                new Pig(){ ID=1,Name="九戒", Age=500},
                new Pig(){ ID=2,Name="八戒1", Age=300},
                new Pig(){ ID=3,Name="十戒1", Age=400}
            };

            //list.AsQueryable().Where(c => c.Age > 1 && c.Name.Contains("八") && true);

            //list.Where() //直接重集合中获取数据
            //list.AsQueryable().Where()  //构造sql语句 根据条件来动态构造 true && c=>c.ID ==1 && c.age>2 && c.Name.StartWith('八')

            //list.AsQueryable().Where(c=>c.ID ==1) ;
            //list.AsQueryable().Where(delegate(Pig c){ return c.ID ==1;}) ;

            Expression codintion = Expression.Constant(true);
            int id = 1;
            int age = 2;

            ParameterExpression p1 = Expression.Parameter(typeof(Pig), "c");

            if (id > 0)
            {
                #region 1.0 构造  c=>c.ID ==1

                MemberExpression m = Expression.PropertyOrField(p1, "ID");
                ConstantExpression c1 = Expression.Constant(id);
                var query1 = Expression.Equal(m, c1); //等价于 c.ID ==1
                //var lambda1=  Expression.Lambda(query1,p1);
                codintion = Expression.And(query1, codintion);   //等价于 true && c.ID ==1
                #endregion
            }

            #region 2.0 构造 c=>c.Age >2
            if (age > 0)
            {
                MemberExpression m2 = Expression.PropertyOrField(p1, "Age");
                ConstantExpression c2 = Expression.Constant(age);
                var query2 = Expression.GreaterThan(m2, c2); // c.Age>2
                //表示将query2 表达式通过and（&&）操作 追加到codintion  后面
                codintion = Expression.And(query2, codintion);  //true && c.ID ==1 && c.Age >2 
            }
            #endregion

            #region 3.0 c=>c.Name.StartWith("八")

            ConstantExpression c3 = Expression.Constant("十");
            //调用stirng中的StartsWith- -->like '八%'方法 (EndsWith -->like '%八') Contains()-> like '%八%'
            var query3 = Expression.Call(
                 Expression.Property(p1, typeof(Pig).GetProperty("Name"))
                , typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) })
               , c3
                );  //c.Name.StartWith("八")

            codintion = Expression.And(query3, codintion);  //true && c.ID ==1 && c.Age >2  && c.Name.StartWith("八")

            #endregion

            Expression<Func<Pig, bool>> queryLambda = Expression.Lambda<Func<Pig, bool>>(codintion, p1);

            Console.WriteLine(queryLambda.ToString());

            var nlist = list.AsQueryable().Where(queryLambda).ToList();
            nlist.ToList().ForEach(c => Console.WriteLine(c.Name));

            Console.ReadKey();
        }
    }

    public class Pig
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


}
