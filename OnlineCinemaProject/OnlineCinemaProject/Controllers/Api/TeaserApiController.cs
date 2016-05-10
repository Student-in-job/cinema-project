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
    public class TeaserApiController : ApiController
            {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();
        [HttpGet]
        [Route("api/teaser/")]
        public HttpResponseMessage GetTeaser() {
            db.Configuration.ProxyCreationEnabled = false;
         
            // string token = "a9fe59b2-8d88-4bef-87f3-a081bcce6632";
            //IEnumerable<string> headerValues;
            //var id_user = string.Empty;
            //if (Request.Headers.TryGetValues("token", out headerValues))
            //{
            //    id_user = headerValues.FirstOrDefault();
            //}
            //SELECT teasers.img_url statistics_teaser from teasers where teasers.id not in (SELECT statistics_teaser.id_teasers from statistics_teaser WHERE statistics_teaser.id_user = '9e0cc9f5-0665-49d4-a009-4c859a00b2d9') 

            string query = "SELECT * FROM teaser order by showAmount asc";

            var teaser = db.teasers.SqlQuery(query).ToList().First();

            var sb = db.statistics_teaser.Find(teaser.id);

            db.teasers.Attach(teaser);
            teaser.showAmount = teaser.showAmount + 1;
            var entry = db.Entry(teaser);
            entry.Property(e => e.showAmount).IsModified = true;
            // other changed properties
            db.SaveChanges();

            if (sb != null)
            {

                db.statistics_teaser.Attach(sb);
                sb.dateShow = DateTime.Now;
                sb.showAmount = teaser.showAmount;
                var entry1 = db.Entry(sb);
                entry1.Property(e => e.showAmount).IsModified = true;
                entry1.Property(e => e.dateShow).IsModified = true;
                // other changed properties
                db.SaveChanges();


            }
            else
            {
                sb = new statistics_teaser();
                sb.dateShow = DateTime.Now;
                sb.id_teasers = teaser.id;
                sb.showAmount = teaser.showAmount;
                sb.id_users = "a9fe59b2-8d88-4bef-87f3-a081bcce6632";
                db.statistics_teaser.Add(sb);
                db.SaveChanges();
            }

           


               string strJSON =   Newtonsoft.Json.JsonConvert.SerializeObject(teaser, Formatting.Indented, 
new JsonSerializerSettings {
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
});
       //     string strJSON = JsonConvert.SerializeObject(teaser,
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

    