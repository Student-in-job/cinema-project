﻿using System;
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
    public class genreController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /genre/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var genres = from s in db.genres select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                genres = genres.Where(s => s.name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    genres = genres.OrderByDescending(s => s.name);
                    break;
                default:
                    genres = genres.OrderBy(s => s.name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(genres.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /genre/Details/5

        public ActionResult Details(int id = 0)
        {
            genre genre = db.genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // GET: /genre/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /genre/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(genre genre)
        {
            if (ModelState.IsValid)
            {
                db.genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(genre);
        }

        //
        // GET: /genre/Edit/5

        public ActionResult Edit(int id = 0)
        {
            genre genre = db.genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /genre/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        //
        // GET: /genre/Delete/5

        public ActionResult Delete(int id = 0)
        {
            genre genre = db.genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /genre/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            genre genre = db.genres.Find(id);
            db.genres.Remove(genre);
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