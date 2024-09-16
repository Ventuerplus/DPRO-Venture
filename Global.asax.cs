using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using ventureerp.Models;
using ventureerp.Services;

namespace ventureerp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //RouteTable.Routes.MapHubs();

            GlobalConfiguration.Configure(WebApiConfig.Register); // <--- this MUST be first 
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //BundleTable.EnableOptimizations = true;
            Database.SetInitializer<ventureerpContext>(null);

            var container = new UnityContainer();
            container.RegisterType<IPayrollService, PayrollService>();

        }
        
    }
}
