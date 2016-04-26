using Newtonsoft.Json;
using OnlineCinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace OnlineCinemaProject.Controllers.Api
{
    public class BannerApiController : ApiController
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();
        [HttpGet]
        [Route("api/banner/")]
        public HttpResponseMessage GetBanner() 
        
        {

            db.Configuration.ProxyCreationEnabled = false;
            // string token = "a9fe59b2-8d88-4bef-87f3-a081bcce6632";
            //IEnumerable<string> headerValues;
            //var id_user = string.Empty;
            //if (Request.Headers.TryGetValues("token", out headerValues))
            //{
            //    id_user = headerValues.FirstOrDefault();
            //}
            //SELECT banners.img_url statistics_banner from banners where banners.id not in (SELECT statistics_banner.id_banner from statistics_banner WHERE statistics_banner.id_user = '9e0cc9f5-0665-49d4-a009-4c859a00b2d9') 

            string query = "SELECT * FROM banners order by show_amount asc";

            var banner = db.banners.SqlQuery(query).ToList().First();

            var sb = db.statistics_banner.Find(banner.id);

            db.banners.Attach(banner);
            banner.show_amount = banner.show_amount + 1;
            var entry = db.Entry(banner);
            entry.Property(e => e.show_amount).IsModified = true;
            // other changed properties
            db.SaveChanges();

            if (sb != null)
            {

                db.statistics_banner.Attach(sb);
                sb.date = DateTime.Now;
                sb.show_amount = (int?) banner.show_amount;
                var entry1 = db.Entry(sb);
                entry1.Property(e => e.show_amount).IsModified = true;
                entry1.Property(e => e.date).IsModified = true;
                // other changed properties
                db.SaveChanges();


            }
            else
            {
                sb = new statistics_banner();
                sb.date = DateTime.Now;
                sb.id_banner = banner.id;
                sb.show_amount = (int?) banner.show_amount;
                sb.id_user = "a9fe59b2-8d88-4bef-87f3-a081bcce6632";
                db.statistics_banner.Add(sb);
                db.SaveChanges();
            }

           string strJSON =   Newtonsoft.Json.JsonConvert.SerializeObject(banner, Formatting.Indented, 
new JsonSerializerSettings {
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
});
       //     string strJSON = JsonConvert.SerializeObject(banner,
       //new EFNavigationPropertyConverter(), new JsonSerializerSettings
       //{
       //    PreserveReferencesHandling = PreserveReferencesHandling.Objects
       //});

           var response = new HttpResponseMessage();
           response.Content = new StringContent(strJSON);
           response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
           return response;
        }

    }
}
