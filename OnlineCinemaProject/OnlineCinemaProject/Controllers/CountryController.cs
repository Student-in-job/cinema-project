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
using PagedList;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "ContentManager")]
    public class CountryController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /Country/

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

            var countries = from s in db.countries select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                countries = countries.Where(s => s.name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    countries = countries.OrderByDescending(s => s.name);
                    break;
                default:
                    countries = countries.OrderBy(s => s.name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(countries.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Country/Details/5

        public ActionResult Details(int id = 0)
        {
            country country = db.countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Country/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(country country)
        {
            if (ModelState.IsValid)
            {
                db.countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        //
        // GET: /Country/Edit/5

        public ActionResult Edit(int id = 0)
        {
            country country = db.countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        //
        // GET: /Country/Delete/5

        public ActionResult Delete(int id = 0)
        {
            country country = db.countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // POST: /Country/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            country country = db.countries.Find(id);
            db.countries.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Countries_read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = db.countries.Select(v => new { v.name, v.id }).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Countries_Create([DataSourceRequest]DataSourceRequest request, country country)
        {
            if (ModelState.IsValid)
            {
                var entity = db.countries.Add(new country { id = country.id, name = country.name });
                db.SaveChanges();
                country.id = entity.id;
            }
            return Json(new[] { country }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Countries_Update([DataSourceRequest]DataSourceRequest request, country country)
        {
            if (ModelState.IsValid)
            {
                var entity = new country()
                {
                    id = country.id,
                    name = country.name
                };
                db.countries.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { country }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Countries_Destroy([DataSourceRequest]DataSourceRequest request, country country)
        {
            if (ModelState.IsValid)
            {
                var entity = new country()
                {
                    id = country.id,
                    name = country.name
                };
                db.countries.Attach(entity);
                db.countries.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { country }.ToDataSourceResult(request, ModelState));
        }
    }
}