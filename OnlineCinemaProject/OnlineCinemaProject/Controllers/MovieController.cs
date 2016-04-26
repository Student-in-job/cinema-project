using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "ContentManager")]
    public class MovieController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /movie/

        public ActionResult Index()
        {
            var movies = db.movies.Include(c => c.video);
            return View(movies.ToList());
        }

        //
        // GET: /movie/Details/5

        public ActionResult Details(int id = 0)
        {
            movy movie = db.movies.Find(id);
            var movieHistory = db.moviehistories.Where(i => i.movie_id == id);
            int watchingAmount = 0;
            foreach (var item in movieHistory)
            {
                ++watchingAmount;
            }
            ViewBag.WatchingAmount = watchingAmount;
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // GET: /movie/Create

        public ActionResult Create()
        {
            ViewBag.video_id = new SelectList(db.videos, "id", "name");
            return View();
        }

        //
        // POST: /movie/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(movy movie)
        {
            if (ModelState.IsValid)
            {
                db.movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.video_id = new SelectList(db.videos, "id", "name", movie.video_id);//todo  choosen 
            return View(movie);
        }

        //
        // GET: /movie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            movy movie = db.movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.video_id = new SelectList(db.videos, "id", "name", movie.video_id);
            return View(movie);
        }

        //
        // POST: /movie/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(movy movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.video_id = new SelectList(db.videos, "id", "name", movie.video_id);
            return View(movie);
        }

        //
        // GET: /movie/Delete/5

        public ActionResult Delete(int id = 0)
        {
            movy movie = db.movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /movie/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movy movie = db.movies.Find(id);
            db.movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddMovieByVideoId(int id)
        {
            video video = db.videos.Find(id);
            ViewBag.VideoType = video.type;
            movy movie = new movy
            {
                video_id = id,
                creation_date = DateTime.Today
            };
            ViewBag.FilmName = db.videos.Find(id).name; 
            return View(movie);
        }
        [HttpPost]
        public ActionResult AddMovieByVideoId(movy movie, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                          + file.FileName);
                    movie.url = file.FileName;
                }
                db.movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index", "Video");
            }
            return View(movie);
        }

        


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Movies_read([DataSourceRequest]DataSourceRequest request, int videoId)
        {
            DataSourceResult result = db.movies.Where(t => t.video_id == videoId).Select(v => new { v.url, v.id,v.creation_date,v.price,v.quality }).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Movies_create([DataSourceRequest]DataSourceRequest request, movy movy, int videoId)
        {
            if (ModelState.IsValid)
            {
                var entity = db.movies.Add(new movy { url = movy.url, video_id = videoId, creation_date = movy.creation_date, price = movy.price, quality = movy.quality});
                db.SaveChanges();
                movy.id = entity.id;
            }
            return Json(new[] { movy }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Movies_update([DataSourceRequest]DataSourceRequest request, movy movy)
        {
            if (ModelState.IsValid)
            {
                var entity = new movy()
                {
                    url = movy.url,
                    creation_date = movy.creation_date,
                    price = movy.price,
                    quality = movy.quality,
                    video_id = movy.video_id
                };
                db.movies.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { movy }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Movies_destroy([DataSourceRequest]DataSourceRequest request, movy movy)
        {
            if (ModelState.IsValid)
            {
                var entity = new movy()
                {
                    id = movy.id
                };
                db.movies.Attach(entity);
                db.movies.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { movy }.ToDataSourceResult(request, ModelState));
        }
    }
}