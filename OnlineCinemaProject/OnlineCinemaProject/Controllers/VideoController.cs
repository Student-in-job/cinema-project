using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.ViewModels;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "ContentManager")]
    public class VideoController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Watch(String videoUrl)
        {
            return new VideoResult(videoUrl);
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
            video.release_date=DateTime.Now;
            return View(video);
        }

        //
        // POST: /Video/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(video video, HttpPostedFileBase file, int[] genres, int[] actors, int[] countries)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                + file.FileName);
                    video.img_url = file.FileName;
                }
                db.videos.Add(video);
                db.SaveChanges();
                UpdateVideoGenres(genres, video);
                UpdateVideoActors(actors, video);
                UpdateVideoCountries(countries, video);
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                video.videoactors = db.actors.Where(t => actors.Contains(t.id)).ToList().Select(t => new videoactor() { actor = new actor { id = t.id, name = t.name }, video = video }).ToList();
                video.videogenres = db.actors.Where(t => actors.Contains(t.id)).ToList().Select(t => new videogenre() { genre = new genre { id = t.id, name = t.name }, video = video }).ToList();
                video.manufacturers = db.actors.Where(t => countries.Contains(t.id)).ToList().Select(t => new manufacturer() { country = new country { id = t.id, name = t.name }, video = video }).ToList();
            }
            return View(video);
        }

        private void UpdateVideoActors(int[] selectedActors, video model)
        {
            if (selectedActors == null)
            {
                model.videogenres = new List<videogenre>();
                return;
            }

            var selectedActorsHS = new HashSet<int>(selectedActors);
            var videoActors = new HashSet<int>(model.videoactors.Select(c => c.actor_id));
            foreach (var actor in db.actors)
            {
                if (selectedActorsHS.Contains(actor.id))
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
                        model.videoactors.Remove(model.videoactors.FirstOrDefault(g => g.actor_id == actor.id));
                    }
                }
            }
        }
        private void UpdateVideoGenres(int[] selectedGenres, video model)
        {
            if (selectedGenres == null)
            {
                model.videogenres = new List<videogenre>();
                return;
            }

            var selectedGenresHS = new HashSet<int>(selectedGenres);
            var videoGenres = new HashSet<int>(model.videogenres.Select(c => c.genre_id));
            foreach (var genre in db.genres)
            {
                if (selectedGenresHS.Contains(genre.id))
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
                        model.videogenres.Remove(model.videogenres.FirstOrDefault(g=>g.genre_id == genre.id));
                    }
                }
            }
        }
        private void UpdateVideoCountries(int[] selectedCountries, video model)
        {
            if (selectedCountries == null)
            {
                model.manufacturers = new List<manufacturer>();
                return;
            }

            var selectedCountriesHS = new HashSet<int>(selectedCountries);
            var videoCountries = new HashSet<int>(model.manufacturers.Select(c => c.country_id));
            foreach (var country in db.countries)
            {
                if (selectedCountriesHS.Contains(country.id))
                {
                    if (!videoCountries.Contains(country.id))
                    {
                        var manufacturer = new manufacturer();
                        manufacturer.country_id = country.id;
                        manufacturer.video_id = model.id;
                        model.manufacturers.Add(manufacturer);
                    }
                }
                else
                {
                    if (videoCountries.Contains(country.id))
                    {
                        model.manufacturers.Remove(model.manufacturers.FirstOrDefault(g => g.country_id == country.id));
                    }
                }
            }
        }

        //
        // GET: /Video/Edit/5

        public ActionResult Edit(int id = 0)
        {
           video video = db.videos.Where(t=>t.id==id)
                .Include("videoactors.actor")
                .Include("videogenres.genre")
                .Include("manufacturers.country")
                .FirstOrDefault();
            if (video == null)
            {
                return HttpNotFound();
            }
            PopulateIncludedVideoData(video);
            return View(video);
        }

        //
        // POST: /Video/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(video video, HttpPostedFileBase file, int[] genres, int[] actors, int[] countries)
        {
            var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                + file.FileName);
                    video.img_url = file.FileName;
                }
                db.Entry(video).State = EntityState.Modified;
                db.Entry(video).Collection(e => e.videoactors).Load();
                db.Entry(video).Collection(e => e.videogenres).Load();
                db.Entry(video).Collection(e => e.manufacturers).Load();
                UpdateVideoGenres(genres, video);
                UpdateVideoActors(actors, video);
                UpdateVideoCountries(countries, video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                video.videoactors = db.actors.Where(t => actors.Contains(t.id)).ToList().Select(t => new videoactor() { actor = new actor { id = t.id, name = t.name }, video = video }).ToList();
                video.videogenres = db.actors.Where(t => actors.Contains(t.id)).ToList().Select(t => new videogenre() { genre = new genre { id = t.id, name = t.name }, video = video }).ToList();
                video.manufacturers = db.actors.Where(t => countries.Contains(t.id)).ToList().Select(t => new manufacturer() { country = new country { id = t.id, name = t.name }, video = video }).ToList();
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

        public PartialViewResult VideoTrailers()
        {
            return PartialView();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void PopulateIncludedVideoData(video video)
        {
            var allGenres = db.genres;
            var allActors = db.actors;
            var allCountries = db.countries;
            var videoGenres = new HashSet<int>(video.videogenres/*.Where(i=>i.video_id==video.id)*/.Select(c => c.genre_id));
            var videoActors = new HashSet<int>(video.videoactors.Select(i=>i.actor_id));
            var videoCountries = new HashSet<int>(video.manufacturers.Select(i=>i.country_id));
            var genreDatas = new List<IncludedData>();
            var actorDatas = new List<IncludedData>();
            var countryDatas = new List<IncludedData>();
            foreach (var genre in allGenres)
            {
                genreDatas.Add(new IncludedData
                {
                    id = genre.id,
                    Title = genre.name,
                    Included = videoGenres.Contains(genre.id)
                });
            }
            foreach (var actor in allActors)
            {
                actorDatas.Add(new IncludedData
                {
                    id = actor.id,
                    Title = actor.name,
                    Included = videoActors.Contains(actor.id)
                });
            }
            foreach (var country in allCountries)
            {
                countryDatas.Add(new IncludedData
                {
                    id = country.id,
                    Title = country.name,
                    Included = videoCountries.Contains(country.id)
                });
            }

            ViewBag.Genres = genreDatas;
            ViewBag.Actors = actorDatas;
            ViewBag.Countries = countryDatas;
            
        }
        [HttpGet]
        public ActionResult CreateNew()
        {
            video video = new video
            {
                release_date = DateTime.Now
            };
            PopulateIncludedVideoData(video);
            return View(video);
        }
        /* [HttpPost]
         public ActionResult CreateNew(video model, HttpPostedFileBase file,)
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

                 return RedirectToAction("Index");
             }

             return View(model);
         }
         [HttpPost]
         public ActionResult SelectGenres(video video)
         {
             return View();
         }*/

        public ActionResult Videos_read([DataSourceRequest]DataSourceRequest request, int? genre, int? actor, int? country)
        {
            DataSourceResult result = db.videos
                .Include("videogenre.genre")
                .Include("videoactor.actor")
                .Include("videogenre.genre")
                .Where(
                    v=>
                        (!genre.HasValue || v.videogenres.Any(g=>g.genre_id==genre.Value))&&
                        (!actor.HasValue || v.videoactors.Any(g=>g.actor_id== actor.Value))&&
                        (!country.HasValue || v.manufacturers.Any(g=>g.country_id== country.Value))
                )
                .Select(v => new 
            {
                    v.name, v.id, v.img_url, v.type, v.release_date,
                    videogenres = v.videogenres.Select(t=>new {genre = new  { t.genre.name} }),
                    videoactors = v.videoactors.Select(t=>new {actor = new  { t.actor.name} }),
                    manufacturers = v.manufacturers.Select(t=>new { country = new  { t.country.name} })
              
            }).ToDataSourceResult(request);
            return Json(result);
        }

        public ContentResult UpdateScore(int id)
        {
            var video = db.videos.FirstOrDefault(v => v.id == id);
            if (video == null)
            {
                return Content("Invalid id");
            }
            video.score = ScoreCallculationJob.GetVideoScore(video, db);
            video.last_score_calc = DateTime.Now;
            db.SaveChanges();
            return Content(video.score.ToString());
        }

        public ActionResult ScoreChart(int id)
        {
            var video = db.videos.FirstOrDefault(v => v.id == id);
            if (video == null)
            {
                return Content("Invalid id");
            }
            var data =
                video.reviews.GroupBy(t => t.rating)
                    .Select(t => new ScoreModel { Score = Convert.ToInt32(t.Key), Count = t.Count() }).OrderBy(t=>t.Score)
                    .ToList();
            return Json(data);
        }
    }
}
