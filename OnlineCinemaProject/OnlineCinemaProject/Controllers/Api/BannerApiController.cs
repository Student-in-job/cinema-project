using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using OnlineCinemaProject.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<banner>("BannerApi");
    builder.EntitySet<advertiser>("advertisers"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BannerApiController : ApiController
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        // GET odata/BannerApi
        [Queryable]
        public IQueryable<banner> GetBannerApi()
        {
            IEnumerable<string> headerValues;
            var token = string.Empty;
            if(Request.Headers.TryGetValues("token", out headerValues)) {
                token = headerValues.FirstOrDefault();
            }

            string query = "SELECT * FROM userbanners WHERE token = @p0 and is_shown = 0 limit 10";
            
            var banners = await db.banners.SqlQuery(query, token).SingleOrDefaultAsync();
            if (banners == null)
            {
                return Ok();
            }

            return Ok(banners);
        }

        // GET odata/BannerApi(5)
        [Queryable]
        public SingleResult<banner> Getbanner([FromODataUri] int key)
        {
            return SingleResult.Create(db.banners.Where(banner => banner.id == key));
        }

        // PUT odata/BannerApi(5)
        public IHttpActionResult Put([FromODataUri] int key, banner banner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != banner.id)
            {
                return BadRequest();
            }

            db.Entry(banner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bannerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(banner);
        }

        // POST odata/BannerApi
        public IHttpActionResult Post(banner banner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.banners.Add(banner);
            db.SaveChanges();

            return Created(banner);
        }

        // PATCH odata/BannerApi(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<banner> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            banner banner = db.banners.Find(key);
            if (banner == null)
            {
                return NotFound();
            }

            patch.Patch(banner);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bannerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(banner);
        }

        // DELETE odata/BannerApi(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            banner banner = db.banners.Find(key);
            if (banner == null)
            {
                return NotFound();
            }

            db.banners.Remove(banner);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/BannerApi(5)/advertiser
        [Queryable]
        public SingleResult<advertiser> Getadvertiser([FromODataUri] int key)
        {
            return SingleResult.Create(db.banners.Where(m => m.id == key).Select(m => m.advertiser));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bannerExists(int key)
        {
            return db.banners.Count(e => e.id == key) > 0;
        }
    }
}
