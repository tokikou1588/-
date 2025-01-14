﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectDependencyResolver dependencyResolver = new NinjectDependencyResolver();
            dependencyResolver.Register<IContactRepository, DefaultContactRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver; 

        }
    }
}