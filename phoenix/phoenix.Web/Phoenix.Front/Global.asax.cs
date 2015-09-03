using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Phoenix.Bll.Essential;
using AutofacDependencyResolver = Autofac.Integration.Mvc.AutofacDependencyResolver;


namespace Phoenix.Front
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac

            var controllerBuilder = new ContainerBuilder();
            
            controllerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = controllerBuilder.Build();

            AutofacContainer.GetContainer().UpdateExternalContainer(container); //BLL dependancies

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
