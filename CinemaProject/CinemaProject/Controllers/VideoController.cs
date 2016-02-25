using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaProject.Models;
using CinemaProject.Models.ViewModels;

namespace CinemaProject.Controllers
{
    public class VideoController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View(db.videos.ToList());
        }

        //
        // GET: /Video/Details/5

        public ActionResult Details(int id = 0)
        {
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        //
        // GET: /Video/Create

        public ActionResult Create()
        {
            video video = new video();
            PopulateAssignedCourseData(video);
            return View(video);
        }

        //
        // POST: /Video/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(video model, HttpPostedFileBase file, FormCollection formCollection, string[] selectedGenres)
        {
            UpdateVideoGenres(selectedGenres, model);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                          + file.FileName);
                    model.img_url = file.FileName;
                }
                db.videos.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedCourseData(model);
            return View(model);
        }

        private void UpdateVideoGenres(string[] selectedGenres, video model)
        {
            if (selectedGenres == null)
            {
                model.genres = new List<genre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var videoGenres = new HashSet<int>(model.genres.Select(c => c.id));
            foreach (var genre in db.genres)
            {
                if (selectedGenresHS.Contains(genre.id.ToString()))
                {
                    if (!videoGenres.Contains(genre.id))
                    {
                        model.genres.Add(genre);
                    }
                }
                else
                {
                    if (videoGenres.Contains(genre.id))
                    {
                        model.genres.Remove(genre);
                    }
                }
            }
        }

        //
        // GET: /Video/Edit/5

        public ActionResult Edit(int id = 0)
        {
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }

            return View(video);
        }

        //
        // POST: /Video/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(video video, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                          + file.FileName);
                    video.img_url = file.FileName;
                }
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        //
        // GET: /Video/Delete/5

        public ActionResult Delete(int id = 0)
        {
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        //
        // POST: /Video/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            video video = db.videos.Find(id);
            db.videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void PopulateAssignedCourseData(video video)
        {
            var allGenres = db.genres;
            var videoGenres = new HashSet<int>(video.genres.Select(c => c.id));
            var viewModel = new List<IncludedGenreData>();
            foreach (var genre in allGenres)
            {
                viewModel.Add(new IncludedGenreData
                {
                    id = genre.id,
                    Title = genre.name,
                    Included = videoGenres.Contains(genre.id)
                });
            }
            ViewBag.Genres = viewModel;
        }
    }
}