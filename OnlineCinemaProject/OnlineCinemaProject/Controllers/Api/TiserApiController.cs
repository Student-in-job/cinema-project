using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
    builder.EntitySet<banner>("TiserApi");
    builder.EntitySet<advertiser>("advertisers"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TiserApiController : ODataController
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        // GET odata/TiserApi
        [Queryable]
        public IQueryable<banner> GetTiserApi()
        {
            return db.banners;
        }

        // GET odata/TiserApi(5)
        [Queryable]
        public SingleResult<banner> Getbanner([FromODataUri] int key)
        {
            return SingleResult.Create(db.banners.Where(banner => banner.id == key));
        }

        // PUT odata/TiserApi(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, banner banner)
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
                await db.SaveChangesAsync();
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

        // POST odata/TiserApi
        public async Task<IHttpActionResult> Post(banner banner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.banners.Add(banner);
            await db.SaveChangesAsync();

            return Created(banner);
        }

        // PATCH odata/TiserApi(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<banner> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            banner banner = await db.banners.FindAsync(key);
            if (banner == null)
            {
                return NotFound();
            }

            patch.Patch(banner);

            try
            {
                await db.SaveChangesAsync();
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

        // DELETE odata/TiserApi(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            banner banner = await db.banners.FindAsync(key);
            if (banner == null)
            {
                return NotFound();
            }

            db.banners.Remove(banner);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/TiserApi(5)/advertiser
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
