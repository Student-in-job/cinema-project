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
    public class SubsciptionController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /Subsciption/

        public ActionResult Index()
        {
            return View(db.subscriptions.ToList());
        }

        //
        // GET: /Subsciption/Details/5

        public ActionResult Details(int id = 0)
        {
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        //
        // GET: /Subsciption/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Subsciption/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscription);
        }

        //
        // GET: /Subsciption/Edit/5

        public ActionResult Edit(int id = 0)
        {
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        //
        // POST: /Subsciption/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscription);
        }

        //
        // GET: /Subsciption/Delete/5

        public ActionResult Delete(int id = 0)
        {
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        //
        // POST: /Subsciption/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subscription subscription = db.subscriptions.Find(id);
            db.subscriptions.Remove(subscription);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult TariffSubscriptions(int id)
        {
            var subscriptions = db.subscriptions.Where(i => i.tariff_id == id).ToList();
            return View(subscriptions);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}