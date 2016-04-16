using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Microsoft.Data.OData.Atom;
using MySql.Data.MySqlClient;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.ViewModels;
using PagedList;

namespace OnlineCinemaProject.Controllers
{
    class GroupedRow : DbContext
    {
        public Decimal Sum { get; set; }
        public int Months { get; set; }
       
    }
    [Authorize(Roles = "BilingManager")]
    public class BillingController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /tariff/

        public ActionResult Index()
        {
            /*var dbRaw =
                db.Database.SqlQuery<Object>(
                    "SELECT MONTHNAME(payment_date) as [Months], SUM(amount) as [Sum] FROM payments GROUP BY MONTH(payment_date)");*/
            /*ICollection<GroupedRow> payments = db.payments
                .GroupBy(p => new
                {
                    Month = p.payment_date.Month
                }).Select(t=>new GroupedRow
                {
                    Months = t.Key.Month,
                    Sum = t.Count()
                }).ToList();*/
            
            return View(db.tariffs.ToList());
        }

            

        public ActionResult Text()
        {
            return View();
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
        public ActionResult Create(TariffViewModel tariffView)
        {
            tariff tariff = new tariff
            {
                name = tariffView.Name,
                description = tariffView.Description,
                creation_date = DateTime.Now,
                active = true,
                adverticement_enabled = tariffView.AdverticementEnabled,
                new_films_enabled = tariffView.NewFilmsEnabled,
                price = tariffView.Price
            };
            if (ModelState.IsValid)
            {
                db.tariffs.Add(tariff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tariffView);
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
            TariffViewModel tariffView = new TariffViewModel
            {
                Id = tariff.id,
                Name = tariff.name,
                Description = tariff.description,
                CreationDate = tariff.creation_date,
                AdverticementEnabled = tariff.adverticement_enabled,
                NewFilmsEnabled = tariff.new_films_enabled,
                Price = tariff.price,
                Subscriptions = tariff.subscriptions
            };
            return View(tariffView);
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