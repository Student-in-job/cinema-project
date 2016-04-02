using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaProject.Models;
using PagedList;

namespace CinemaProject.Controllers
{
    public class tariffController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /tariff/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tarrifs = from s in db.tariffs select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                tarrifs = tarrifs.Where(s => s.name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    tarrifs = tarrifs.OrderByDescending(s => s.name);
                    break;
                case "Price":
                    tarrifs = tarrifs.OrderBy(s => s.price);
                    break;
                case "Price_desc":
                    tarrifs = tarrifs.OrderByDescending(s => s.price);
                    break;
                default:
                    tarrifs = tarrifs.OrderBy(s => s.name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tarrifs.ToPagedList(pageNumber, pageSize));

        }

        //
        // GET: /tariff/Details/5

        public ActionResult Details(int id = 0)
        {
            tariff tariff = db.tariffs.Find(id);
            if (tariff == null)
            {
                return HttpNotFound();
            }
            return View(tariff);
        }

        //
        // GET: /tariff/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /tariff/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tariff tariff)
        {
            tariff.creation_date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.tariffs.Add(tariff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tariff);
        }

        //
        // GET: /tariff/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tariff tariff = db.tariffs.Find(id);
            if (tariff == null)
            {
                return HttpNotFound();
            }
            return View(tariff);
        }

        //
        // POST: /tariff/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tariff tariff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tariff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tariff);
        }

        //
        // GET: /tariff/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tariff tariff = db.tariffs.Find(id);
            if (tariff == null)
            {
                return HttpNotFound();
            }
            return View(tariff);
        }

        //
        // POST: /tariff/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tariff tariff = db.tariffs.Find(id);
            db.tariffs.Remove(tariff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

//        public ActionResult Subscribtions(int id)
//        {
//            return View("Subscribtion");
//        }
    }
}