using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<video>("Video");
            builder.EntitySet<like>("like");
            builder.EntitySet<manufacturer>("manufacturer");
            builder.EntitySet<overview>("overview");
            builder.EntitySet<season>("season");
            builder.EntitySet<trailer>("trailer");
            builder.EntitySet<videoactor>("videoactor");
            builder.EntitySet<videogenre>("videogenre");
            builder.EntitySet<movy>("movy");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
