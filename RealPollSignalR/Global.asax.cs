using Microsoft.AspNet.SignalR;
using Ninject;
using RealPollSignalR.App_Start;
using RealPollSignalR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RealPollSignalR
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetupDI();
        }

        private void SetupDI()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IQuestionRepository>().To<DBQuestionRepository>();

            var depencencyResolver = new NinjectDepencencyResolver(kernel);
            DependencyResolver.SetResolver(depencencyResolver);
            GlobalHost.DependencyResolver = depencencyResolver;
        }
    }
}
