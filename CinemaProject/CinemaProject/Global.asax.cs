using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CinemaProject
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public override void Init()
        {
            base.Init();
            this.BeginRequest += GlobalBeginRequest;
        }

        private void GlobalBeginRequest(object sender, EventArgs e)
        {
            var runTime = (HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime");
            var maxRequestLength = runTime.MaxRequestLength * 1024;

            if (Request.ContentLength > maxRequestLength)
            {
                // или другой свой код обработки
                Response.Redirect("~/filetoolarge/");
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}