using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS11.Site.App_Start
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration;
    using EMS11.IDal;
    using EMS11.Dal;
    using System.Reflection;

    public class AutoFacConfig
    {
        public static void RegisterFac()
        {
            //1.0 开始创建一个autofac容器对象
            var bulider = new ContainerBuilder();

            //1.0 重新注册控制器消除错误“没有为该对象定义无参数的构造函数。” 注册当前Fr.MVC.Site的程序集
            var ass = Assembly.Load("EMS11.Site");
            bulider.RegisterControllers(ass);

            //2.0 利用第1步创建好的容器对象注册需要依赖注入的具体实现类（先注册basedal<TEntity>到 ibasedal<TEntity>接口）
            bulider
                .RegisterGeneric(typeof(BaseDal<>))  //注册泛型类BaseDal<> 的类型
                .As(typeof(IBaseDal<>))                     //强制转换成 IBaseDal<> 的类型
                .InstancePerHttpRequest();                 //每一次HTTP的请求都创建一个新的BaseDal<> 类的实体

            //3.0 将网站控制器与BLL关联起来
            //bulider
            //    .RegisterAssemblyTypes(System.Reflection.Assembly.Load("EMS11.BLL"))  //注册当前EMS11.BLL程序集中的所有类
            //    .AsImplementedInterfaces()
            //    .InstancePerHttpRequest();    //每一次HTTP的请求都创建一个新的 类的实体
            //遍历当前EMS11.BLL 程序集中后缀为Services结尾的类 bulider.RegisterTypes(Assembly.Load("EMS11.BLL").GetTypes().Where(c => c.Name.EndsWith("Services")).ToArray()).AsImplementedInterfaces().InstancePerHttpRequest();

            //遍历当前EMS11.BLL 程序集中所有的类
            bulider.RegisterTypes(Assembly.Load("EMS11.BLL").GetTypes()).AsImplementedInterfaces();//.InstancePerHttpRequest();


            //4.0 将MVC.net创建控制器对象的权利交给autofac.dll
            //4.0.1 根据已经注册好的组建创建一个新的容器
            var container = bulider.Build();

            // 4.02 将MVC的控制器对象实例 交由autofac来创建
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}