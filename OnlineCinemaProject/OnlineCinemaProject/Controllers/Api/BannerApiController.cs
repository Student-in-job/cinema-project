using Newtonsoft.Json;
using OnlineCinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using OnlineCinemaProject.CustomResult;

namespace OnlineCinemaProject.Controllers.Api
{
    public class BannerApiController : ApiController
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();


        [HttpGet]
        [Route("api/banner/")]
        public JSendResponse GetBanner()
        {

            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<string> headerValues;
            var id_user = string.Empty;
            if (Request.Headers.TryGetValues("token", out headerValues))
            {
                id_user = headerValues.FirstOrDefault();
            }
            //SELECT banners.img_url statistics_banner from banners where banners.id not in (SELECT statistics_banner.id_banner from statistics_banner WHERE statistics_banner.id_user = '9e0cc9f5-0665-49d4-a009-4c859a00b2d9') 



            if (!id_user.Equals(""))
            {
                var user = db.aspnetusers.FirstOrDefault(i=>i.Id == id_user);
                if (user == null)
                {
                    return JSendResponse.errorResponse(Error.UserNotFound());
                }

                /*var sub = user.subscriptions.Where(i => i.tariff_id == user.TariffId).OrderBy(i => i.start).ToList();.First();
                if (sub.Count != 0)
                {
                    if (sub.First().Active() && user.tariff.adverticement_enabled == false)
                    {
                        return JSendResponse.errorResponse(Error.AdverticementDisabled());
                    }
                }*/
                var subs = db.subscriptions.Where(i => i.tariff_id == user.TariffId && id_user  == user.Id).OrderByDescending(i => i.start).ToList().FirstOrDefault();
                if (subs != null)
                {
                    var tariff = db.tariffs.Find(user.TariffId);
                    if (subs.Active() && tariff.adverticement_enabled == false)
                    {
                        return JSendResponse.errorResponse(Error.AdverticementDisabled());
                    }
                }
                

            }

            string query = "SELECT * FROM banners where active = '1' order by show_amount asc";

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
                sb.show_amount = (int?)banner.show_amount;
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
                sb.show_amount = (int?)banner.show_amount;
                sb.id_user = id_user;
                db.statistics_banner.Add(sb);
                db.SaveChanges();
            }

           
            BannerInfo bannerInfo = new BannerInfo()
            {
                id = banner.id,
                img_url = banner.img_url,
                site_url = banner.url

            };

            return JSendResponse.succsessResponse(bannerInfo);
        }


        /*[HttpGet]
        [Route("api/banner/")]
        public HttpResponseMessage GetBanner()         
        {

            db.Configuration.ProxyCreationEnabled = false;
            // string token = "a9fe59b2-8d88-4bef-87f3-a081bcce6632";
            IEnumerable<string> headerValues;
            var id_user = string.Empty;
            if (Request.Headers.TryGetValues("token", out headerValues))
            {
                id_user = headerValues.FirstOrDefault();
            }
            //SELECT banners.img_url statistics_banner from banners where banners.id not in (SELECT statistics_banner.id_banner from statistics_banner WHERE statistics_banner.id_user = '9e0cc9f5-0665-49d4-a009-4c859a00b2d9') 



            if (!id_user.Equals(""))
            {
                var user = db.aspnetusers.Find(id_user);
                if (user == null)
                {
                    return JSendResponse.errorResponse(Error.UserNotFound());
                }
                var sub = user.subscriptions.Where(i => i.tariff_id == user.TariffId).OrderBy(i => i.start).First();
                if (sub.Active() && user.tariff.adverticement_enabled == false)
                {
                    return JSendResponse.succsessResponse(Error.AdverticementDisabled());
                }
            }

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
                sb.id_user = id_user;
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
*/



        /*public JSendResponse GetTrueBanner()
        {
            IEnumerable<string> headerValues;
            var id_user = string.Empty;
            if (Request.Headers.TryGetValues("token", out headerValues))
            {
                id_user = headerValues.FirstOrDefault();
            }
            if (!id_user.Equals(""))
            {
                var user = db.aspnetusers.Find(id_user);
                if (user == null)
                {
                    return JSendResponse.errorResponse(Error.UserNotFound());
                }
                var sub = user.subscriptions.Where(i => i.tariff_id == user.TariffId).OrderBy(i => i.start).First();
                if (sub.Active() &&  user.tariff.adverticement_enabled == false)
                {
                    return JSendResponse.succsessResponse(Error.AdverticementDisabled());
                }
            }

            

            var banner = db.banners.OrderBy(i=>i.show_amount).ToList().First();
            banner.show_amount += 1;
            db.Entry(banner).State = EntityState.Modified;
            db.SaveChanges();

            
            var statisticsBanner = new statistics_banner();
            statisticsBanner.id_user = id_user;
            statisticsBanner.banner = banner;
            statisticsBanner.date = DateTime.Now;

            db.statistics_banner.Add(statisticsBanner);
            db.SaveChanges();

            BannerInfo bannerInfo = new BannerInfo()
            {
                id = banner.id,
                img_url = banner.img_url,

            };

            return JSendResponse.succsessResponse();
        }*/

    }
}
