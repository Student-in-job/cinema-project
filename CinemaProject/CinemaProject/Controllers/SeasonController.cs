using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaProject.Models;

namespace CinemaProject.Controllers
{
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
    }
}