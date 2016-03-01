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
    public class TrailerController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /Trailer/

        public ActionResult Index()
        {
            var trailers = db.trailers.Include(t => t.video);
            return View(trailers.ToList());
        }

        //
        // GET: /Trailer/Details/5

        public ActionResult Details(int id = 0)
        {
            trailer trailer = db.trailers.Find(id);
            if (trailer == null)
            {
                return HttpNotFound();
            }
            return View(trailer);
        }

        //
        // GET: /Trailer/Create

        public ActionResult Create()
        {
            ViewBag.video_id = new SelectList(db.videos, "id", "name");
            return View();
        }

        //
        // POST: /Trailer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(trailer trailer)
        {
            if (ModelState.IsValid)
            {
                db.trailers.Add(trailer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.video_id = new SelectList(db.videos, "id", "name", trailer.video_id);
            return View(trailer);
        }

        //
        // GET: /Trailer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            trailer trailer = db.trailers.Find(id);
            if (trailer == null)
            {
                return HttpNotFound();
            }
            ViewBag.video_id = new SelectList(db.videos, "id", "name", trailer.video_id);
            return View(trailer);
        }

        //
        // POST: /Trailer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(trailer trailer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trailer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.video_id = new SelectList(db.videos, "id", "name", trailer.video_id);
            return View(trailer);
        }

        //
        // GET: /Trailer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            trailer trailer = db.trailers.Find(id);
            if (trailer == null)
            {
                return HttpNotFound();
            }
            return View(trailer);
        }

        //
        // POST: /Trailer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trailer trailer = db.trailers.Find(id);
            db.trailers.Remove(trailer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult AddTrailerByVideoId(int video_id)
        {
            trailer trailer = new trailer
            {
                video_id = video_id
            };

            return View(trailer);
        }
        [HttpPost]
        public ActionResult AddTrailerByVideoId(trailer trailer, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                          + file.FileName);
                    trailer.url = "/uploads/" + file.FileName;
                }
                db.trailers.Add(trailer);
                db.SaveChanges();
                return RedirectToAction("Index", "Video");
            }
            return View(trailer);
        }
    }
}