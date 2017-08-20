using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using xzmcwjzs.ntu.MVC.UI.Utility.Filter;
using xzmcwjzs.ntu.MVC.UI.Utility.Unity;

namespace xzmcwjzs.ntu.MVC.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
             
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());//设置ioc工厂

            RegisterGlobalFilters(GlobalFilters.Filters);//注册全局filter
        }

        /// <summary>
        /// 注册全局filter
        /// </summary>
        /// <param name="filters"></param>
        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogExceptionFilter());
        }

    }
}
