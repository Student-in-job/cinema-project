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
    public class EpisodeController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /Episode/

        public ActionResult Index()
        {
            var episodes = db.episodes.Include(e => e.season);
            return View(episodes.ToList());
        }

        //
        // GET: /Episode/Details/5

        public ActionResult Details(int id = 0)
        {
            episode episode = db.episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            return View(episode);
        }

        //
        // GET: /Episode/Create

        public ActionResult Create()
        {
            ViewBag.season_id = new SelectList(db.seasons, "id", "name");
            return View();
        }

        //
        // POST: /Episode/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(episode episode)
        {
            if (ModelState.IsValid)
            {
                db.episodes.Add(episode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.season_id = new SelectList(db.seasons, "id", "name", episode.season_id);
            return View(episode);
        }

        //
        // GET: /Episode/Edit/5

        public ActionResult Edit(int id = 0)
        {
            episode episode = db.episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            ViewBag.season_id = new SelectList(db.seasons, "id", "name", episode.season_id);
            return View(episode);
        }

        //
        // POST: /Episode/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(episode episode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(episode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.season_id = new SelectList(db.seasons, "id", "name", episode.season_id);
            return View(episode);
        }

        //
        // GET: /Episode/Delete/5

        public ActionResult Delete(int id = 0)
        {
            episode episode = db.episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            return View(episode);
        }

        //
        // POST: /Episode/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            episode episode = db.episodes.Find(id);
            db.episodes.Remove(episode);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult AddEpisodeBySeasonId(int season_id)
        {
            episode episode = new episode
            {
                season_id = season_id
            };
            return View(episode);
        }
        [HttpPost]
        public ActionResult AddEpisodeBySeasonId(episode episode)
        {
            if (ModelState.IsValid)
            {
                db.episodes.Add(episode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.season_id = new SelectList(db.seasons, "id", "name", episode.season_id);
            return View(episode);
        }

        public ActionResult Episodes_read([DataSourceRequest]DataSourceRequest request, int seasondId)
        {
            DataSourceResult result = db.episodes.Where(t => t.season_id == seasondId).Select(v => new { v.url, v.id, v.name }).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Episodes_create([DataSourceRequest]DataSourceRequest request, episode episode, int seasondId)
        {
            if (ModelState.IsValid)
            {
                var entity = db.episodes.Add(new episode { url = episode.url, season_id = seasondId, name = episode.name});
                db.SaveChanges();
                episode.id = entity.id;
            }
            return Json(new[] { episode }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Episodes_update([DataSourceRequest]DataSourceRequest request, episode episode)
        {
            if (ModelState.IsValid)
            {
                var entity = new episode()
                {
                    url = episode.url,
                    season_id = episode.season_id,
                    name = episode.name
                };
                db.episodes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { episode }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Episodes_destroy([DataSourceRequest]DataSourceRequest request, episode episode)
        {
            if (ModelState.IsValid)
            {
                var entity = new episode()
                {
                    id = episode.id
                };
                db.episodes.Attach(entity);
                db.episodes.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { episode }.ToDataSourceResult(request, ModelState));
        }
    }
}