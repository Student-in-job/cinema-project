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
    */
    public class VideoController : ODataController
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        // GET odata/Video
        [Queryable]
        public IQueryable<video> GetVideo()
        {
            return db.videos;
        }

        // GET odata/Video(5)
        [Queryable]
        public SingleResult<video> Getvideo([FromODataUri] int key)
        {
            return SingleResult.Create(db.videos.Where(video => video.id == key));
        }

        // PUT odata/Video(5)
        public IHttpActionResult Put([FromODataUri] int key, video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != video.id)
            {
                return BadRequest();
            }

            db.Entry(video).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!videoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(video);
        }

        // POST odata/Video
        public IHttpActionResult Post(video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.videos.Add(video);
            db.SaveChanges();

            return Created(video);
        }

        // PATCH odata/Video(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<video> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            video video = db.videos.Find(key);
            if (video == null)
            {
                return NotFound();
            }

            patch.Patch(video);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!videoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(video);
        }

        // DELETE odata/Video(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            video video = db.videos.Find(key);
            if (video == null)
            {
                return NotFound();
            }

            db.videos.Remove(video);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Video(5)/likes
        [Queryable]
        public IQueryable<like> Getlikes([FromODataUri] int key)
        {
            return db.videos.Where(m => m.id == key).SelectMany(m => m.likes);
        }

        // GET odata/Video(5)/manufacturers
        [Queryable]
        public IQueryable<manufacturer> Getmanufacturers([FromODataUri] int key)
        {
            return db.videos.Where(m => m.id == key).SelectMany(m => m.manufacturers);
        }

        // GET odata/Video(5)/overviews
        [Queryable]
        public IQueryable<overview> Getoverviews([FromODataUri] int key)
        {
            return db.videos.Where(m => m.id == key).SelectMany(m => m.overviews);
        }

        // GET odata/Video(5)/seasons
        [Queryable]
        public IQueryable<season> Getseasons([FromODataUri] int key)
        {
            return db.videos.Where(m => m.id == key).SelectMany(m => m.seasons);
        }

        // GET odata/Video(5)/trailers
        [Queryable]
        public IQueryable<trailer> Gettrailers([FromODataUri] int key)
        {
            return db.videos.Where(m => m.id == key).SelectMany(m => m.trailers);
        }

        // GET odata/Video(5)/videoactors
        [Queryable]
        public IQueryable<videoactor> Getvideoactors([FromODataUri] int key)
        {
            return db.videos.Where(m => m.id == key).SelectMany(m => m.videoactors);
        }

        // GET odata/Video(5)/videogenres
        [Queryable]
        public IQueryable<videogenre> Getvideogenres([FromODataUri] int key)
        {
            return db.videos.Where(m => m.id == key).SelectMany(m => m.videogenres);
        }

        // GET odata/Video(5)/movies
        [Queryable]
        public IQueryable<movy> Getmovies([FromODataUri] int key)
        {
            return db.videos.Where(m => m.id == key).SelectMany(m => m.movies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool videoExists(int key)
        {
            return db.videos.Count(e => e.id == key) > 0;
        }
    }
}
