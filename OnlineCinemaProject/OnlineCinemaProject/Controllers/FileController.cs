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
    public class FileController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /file/

        public ActionResult Index()
        {
            var files = db.files.Include(c => c.video);
            return View(files.ToList());
        }

        //
        // GET: /file/Details/5

        public ActionResult Details(int id = 0)
        {
            file file = db.files.Find(id);
            var fileHistory = db.histories.Where(i => i.file_id == id);
            int watchingAmount = 0;
            foreach (var item in fileHistory)
            {
                ++watchingAmount;
            }
            ViewBag.WatchingAmount = watchingAmount;
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        //
        // GET: /file/Create

        public ActionResult Create()
        {
            ViewBag.video_id = new SelectList(db.videos, "id", "name");
            return View();
        }

        //
        // POST: /file/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(file file)
        {
            if (ModelState.IsValid)
            {
                db.files.Add(file);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.video_id = new SelectList(db.videos, "id", "name", file.video_id);//todo  choosen 
            return View(file);
        }

        //
        // GET: /file/Edit/5

        public ActionResult Edit(int id = 0)
        {
            file file = db.files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            ViewBag.video_id = new SelectList(db.videos, "id", "name", file.video_id);
            return View(file);
        }

        //
        // POST: /file/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(file file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.video_id = new SelectList(db.videos, "id", "name", file.video_id);
            return View(file);
        }

        //
        // GET: /file/Delete/5

        public ActionResult Delete(int id = 0)
        {
            file file = db.files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        //
        // POST: /file/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            file file = db.files.Find(id);
            db.files.Remove(file);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddFileByVideoId(int id)
        {
            video video = db.videos.Find(id);
            ViewBag.VideoType = video.type;
            file file = new file
            {
                video_id = id,
                creation_date = DateTime.Today
            };
            ViewBag.FilmName = db.videos.Find(id).name; 
            return View(file);
        }
        [HttpPost]
        public ActionResult AddFileByVideoId(file file, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadFile != null)
                {
                    uploadFile.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                          + uploadFile.FileName);
                    file.url = uploadFile.FileName;
                }
                db.files.Add(file);
                db.SaveChanges();
                return RedirectToAction("Index", "Video");
            }
            return View(file);
        }

        


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Files_read([DataSourceRequest]DataSourceRequest request, int videoId)
        {
            DataSourceResult result = db.files.Where(t => t.video_id == videoId).Select(v => new { v.url, v.id,v.creation_date,v.price,v.quality }).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Files_create([DataSourceRequest]DataSourceRequest request, file file, int videoId)
        {
            if (ModelState.IsValid)
            {
                var entity = db.files.Add(new file { url = file.url, video_id = videoId, creation_date = file.creation_date, price = file.price, quality = file.quality, trailer = false});
                db.SaveChanges();
                file.id = entity.id;
            }
            return Json(new[] { file }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Files_update([DataSourceRequest]DataSourceRequest request, file file)
        {
            if (ModelState.IsValid)
            {
                var entity = new file()
                {
                    url = file.url,
                    creation_date = file.creation_date,
                    price = file.price,
                    quality = file.quality,
                    video_id = file.video_id
                };
                db.files.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { file }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Files_destroy([DataSourceRequest]DataSourceRequest request, file file)
        {
            if (ModelState.IsValid)
            {
                var entity = new file()
                {
                    id = file.id
                };
                db.files.Attach(entity);
                db.files.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { file }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Trailers_read([DataSourceRequest]DataSourceRequest request, int videoId)
        {
            DataSourceResult result = db.files.Where(t => t.video_id == videoId && t.trailer == true).Select(v => new { v.id, v.url, v.title, v.video_id }).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Trailers_create([DataSourceRequest]DataSourceRequest request, file modelFile, int videoId)
        {
            if (ModelState.IsValid)
            {
                var entity = db.files.Add(new file { video_id = videoId, url = modelFile.url, title = modelFile.title, trailer = true, creation_date = DateTime.Now });
                db.SaveChanges();
                modelFile.id = entity.id;
            }
            return Json(new[] { modelFile }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Trailers_update([DataSourceRequest]DataSourceRequest request, file trailer)
        {
            if (ModelState.IsValid)
            {
                var entity = new file
                {
                    title = trailer.title,
                    url = trailer.url,
                    video_id = trailer.video_id
                };
                db.files.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { trailer }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Trailers_destroy([DataSourceRequest]DataSourceRequest request, file trailer)
        {
            if (ModelState.IsValid)
            {
                var entity = new file
                {
                    id = trailer.id
                };
                db.files.Attach(entity);
                db.files.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { trailer }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Episodes_read([DataSourceRequest]DataSourceRequest request, int seasondId)
        {
            DataSourceResult result = db.files.Where(t => t.season_id == seasondId).Select(v => new { v.url, v.id, v.title }).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Episodes_create([DataSourceRequest]DataSourceRequest request, file episode, int seasondId)
        {
            if (ModelState.IsValid)
            {
                var entity = db.files.Add(new file { url = episode.url, season_id = seasondId, title = episode.title, trailer = false});
                db.SaveChanges();
                episode.id = entity.id;
            }
            return Json(new[] { episode }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Episodes_update([DataSourceRequest]DataSourceRequest request, file episode)
        {
            if (ModelState.IsValid)
            {
                var entity = new file
                {
                    url = episode.url,
                    season_id = episode.season_id,
                    title = episode.title
                };
                db.files.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { episode }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Episodes_destroy([DataSourceRequest]DataSourceRequest request, file episode)
        {
            if (ModelState.IsValid)
            {
                var entity = new file
                {
                    id = episode.id
                };
                db.files.Attach(entity);
                db.files.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { episode }.ToDataSourceResult(request, ModelState));
        }
    }
    
}