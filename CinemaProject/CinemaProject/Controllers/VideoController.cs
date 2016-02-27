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
            PopulateIncludedGenresData(video);
            return View(video);
        }

        //
        // POST: /Video/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(video model, HttpPostedFileBase file, string[] selectedGenres, string[] selectedActors)
        {
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
//                var LastVideo = db.videos.Last();


                UpdateVideoGenres(selectedGenres, model);
                UpdateVideoActors(selectedGenres, model);

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            PopulateIncludedGenresData(model);
            return View(model);
        }

        private void UpdateVideoActors(string[] selectedActors, video model)
        {
            if (selectedActors == null)
            {
                model.videogenres = new List<videogenre>();
                return;
            }

            var selectedActorsHS = new HashSet<string>(selectedActors);
            var videoActors = new HashSet<int>(model.videoactors.Select(c => c.actor_id));
            foreach (var actor in db.actors)
            {
                if (selectedActorsHS.Contains(actor.id.ToString()))
                {
                    if (!videoActors.Contains(actor.id))
                    {
                        var videoactor = new videoactor();
                        videoactor.actor_id = actor.id;
                        videoactor.video_id = model.id;
                        model.videoactors.Add(videoactor);
                    }
                }
                else
                {
                    if (videoActors.Contains(actor.id))
                    {
                        var videoactor = new videoactor();
                        videoactor.actor_id = actor.id;
                        videoactor.video_id = model.id;
                        model.videoactors.Remove(videoactor);
                    }
                }
            }
        }

        private void UpdateVideoGenres(string[] selectedGenres, video model)
        {
            if (selectedGenres == null)
            {
                model.videogenres = new List<videogenre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var videoGenres = new HashSet<int>(model.videogenres.Select(c => c.genre_id));
            foreach (var genre in db.genres)
            {
                if (selectedGenresHS.Contains(genre.id.ToString()))
                {
                    if (!videoGenres.Contains(genre.id))
                    {
                        var videogenre = new videogenre();
                        videogenre.genre_id = genre.id;
                        videogenre.video_id = model.id;
                        model.videogenres.Add(videogenre);
                    }
                }
                else
                {
                    if (videoGenres.Contains(genre.id))
                    {
                        var videogenre = new videogenre();
                        videogenre.genre_id = genre.id;
                        videogenre.video_id = model.id;
                        model.videogenres.Remove(videogenre);
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
            PopulateIncludedGenresData(video);
            return View(video);
        }

        //
        // POST: /Video/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(video video, HttpPostedFileBase file, string[] selectedGenres)
        {
            UpdateVideoGenres(selectedGenres, video);
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

        private void PopulateIncludedGenresData(video video)
        {
            var allGenres = db.genres;
            var allActors = db.actors;
            var videoGenres = new HashSet<int>(video.videogenres/*.Where(i=>i.video_id==video.id)*/.Select(c => c.genre_id));
            var videoActors = new HashSet<int>(video.videoactors.Select(i=>i.actor_id));
            var genreDatas = new List<IncludedGenreData>();
            var actorDatas = new List<IncludedGenreData>();
            foreach (var genre in allGenres)
            {
                genreDatas.Add(new IncludedGenreData
                {
                    id = genre.id,
                    Title = genre.name,
                    Included = videoGenres.Contains(genre.id)
                });
            }
            foreach (var actor in allActors)
            {
                actorDatas.Add(new IncludedGenreData
                {
                    id = actor.id,
                    Title = actor.name,
                    Included = videoActors.Contains(actor.id)
                });
            }
            ViewBag.Genres = genreDatas;
            ViewBag.Actors = actorDatas;
            
        }
    }
}