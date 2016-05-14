using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "ContentManager")]
    public class SeasonController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /Season/

        public ActionResult Index()
        {
            var seasons = db.seasons.Include(s => s.video);
            return View(seasons.ToList());
        }

        //
        // GET: /Season/Details/5

        public ActionResult Details(int id = 0)
        {
            season season = db.seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        //
        // GET: /Season/Create

        public ActionResult Create()
        {
            ViewBag.video_id = new SelectList(db.videos, "id", "name");
            return View();
        }

        //
        // POST: /Season/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(season season)
        {
            if (ModelState.IsValid)
            {
                db.seasons.Add(season);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.video_id = new SelectList(db.videos, "id", "name", season.video_id);
            return View(season);
        }

        //
        // GET: /Season/Edit/5

        public ActionResult Edit(int id = 0)
        {
            season season = db.seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            ViewBag.video_id = new SelectList(db.videos, "id", "name", season.video_id);
            return View(season);
        }

        //
        // POST: /Season/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(season season)
        {
            if (ModelState.IsValid)
            {
                db.Entry(season).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.video_id = new SelectList(db.videos, "id", "name", season.video_id);
            return View(season);
        }

        //
        // GET: /Season/Delete/5

        public ActionResult Delete(int id = 0)
        {
            season season = db.seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        //
        // POST: /Season/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            season season = db.seasons.Find(id);
            db.seasons.Remove(season);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult AddSeasonByVideoId(int id)
        {
            season season = new season
            {
                release_date = DateTime.Now,
                video_id = id
            };
            return View(season);
        }
        [HttpPost]
        public ActionResult AddSeasonByVideoId(season season)
        {
            if (ModelState.IsValid)
            {
                db.seasons.Add(season);
                db.SaveChanges();
                return RedirectToAction("Index", "Video");
            }

            ViewBag.video_id = new SelectList(db.videos, "id", "name", season.video_id);
            return View(season);
        }


        public ActionResult Seasons_read([DataSourceRequest]DataSourceRequest request, int videoId)
        {
            DataSourceResult result = db.seasons.Where(t => t.video_id == videoId).Select(v => new { v.release_date, v.id, v.title, v.price }).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Seasons_create([DataSourceRequest]DataSourceRequest request, season season, int videoId)
        {
            if (ModelState.IsValid)
            {
                var entity = db.seasons.Add(new season { video_id = videoId, release_date = season.release_date, price = season.price, title = season.title });
                db.SaveChanges();
                season.id = entity.id;
            }
            return Json(new[] { season }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Seasons_update([DataSourceRequest]DataSourceRequest request, season season)
        {
            if (ModelState.IsValid)
            {
                var entity = new season()
                {
                    release_date = season.release_date,
                    price = season.price,
                    title = season.title,
                    video_id = season.video_id
                };
                /*db.seasons.Attach(entity);*/
                db.Entry(season).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { season }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Seasons_destroy([DataSourceRequest]DataSourceRequest request, season season)
        {
            if (ModelState.IsValid)
            {
                var entity = new season()
                {
                    id = season.id
                };
                db.seasons.Attach(entity);
                db.seasons.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { season }.ToDataSourceResult(request, ModelState));
        }
    }
}