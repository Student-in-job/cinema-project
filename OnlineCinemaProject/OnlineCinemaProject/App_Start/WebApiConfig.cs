using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();
//			config.MessageHandlers.Add(new WrappingHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
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
            builder.EntitySet<moviehistory>("moviehistory");
            builder.EntitySet<usermovy>("usermovy");
            builder.EntitySet<episode>("episode");
            builder.EntitySet<episodehistory>("episodehistory");
            builder.EntitySet<aspnetuser>("aspnetuser");
            builder.EntitySet<payment>("payment");
            builder.EntitySet<userseason>("userseason");
            builder.EntitySet<subscription>("subscription");
            builder.EntitySet<statistics_banner>("statistics_banner");
            builder.EntitySet<statistics_teaser>("statistics_teaser");
            builder.EntitySet<aspnetrole>("aspnetrole");
            builder.EntitySet<teaser>("teaser");

            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
