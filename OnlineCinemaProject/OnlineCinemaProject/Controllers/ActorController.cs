using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCinemaProject.Models;
using PagedList;

namespace OnlineCinemaProject.Controllers
{
    public class ActorController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /actor/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var actors = from s in db.actors select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                actors = actors.Where(s => s.name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    actors = actors.OrderByDescending(s => s.name);
                    break;
                default:
                    actors = actors.OrderBy(s => s.name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(actors.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /actor/Details/5

        public ActionResult Details(int id = 0)
        {
            actor actor = db.actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // GET: /actor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /actor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(actor actor)
        {
            if (ModelState.IsValid)
            {
                db.actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        //
        // GET: /actor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            actor actor = db.actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /actor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        //
        // GET: /actor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            actor actor = db.actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /actor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            actor actor = db.actors.Find(id);
            db.actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}