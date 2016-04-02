using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.Month);
            }
        }
    }
    [Authorize(Roles = "BilingManager")]
    public class BillingController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        //
        // GET: /tariff/

        public ActionResult Index()
        {
            //ICollection<GroupedRow> payments = db.payments
            //    .GroupBy(p => new
            //    {
            //        Month = p.payment_date.Month
            //    }).Select(t=>new GroupedRow
            //    {
            //        Month = t.Key.Month,
            //        Sum = t.Count()
            //    }).ToList();

//            string query = "";
//            var paym = db.payments.Dy("SELECT MONTHNAME(payment_date), SUM(amount) FROM payments GROUP BY YEAR(payment_date), MONTH(payment_date)");
//            var xDataMonths = groupedRows.Select(p => p.PaymentDate).ToArray();
//            var yDataSumms = groupedRows.Select(p => p.Sum).ToArray();
//            //Create Series 1
//            var series1 = new Series {Name = "Area Series 1"};
//            Point[] series1Points =
//                {
//                    new Point() {X = 0.0, Y = 0.0},
//                    new Point() {X = 10.0, Y = 0.0},
//                    new Point() {X = 10.0, Y = 10.0},
//                    new Point() {X = 0.0, Y = 10.0}
//                };
//            series1.Data = new Data(series1Points);
//
//            //Create Series 2
//            var series2 = new Series {Name = "Area Series 1"};
//            Point[] series2Points =
//                {
//                    new Point() {X = 5.0, Y = 5.0},
//                    new Point() {X = 15.0, Y =5.0},
//                    new Point() {X = 15.0, Y = 15.0},
//                    new Point() {X = 5.0, Y = 15.0}
//                };
//            series2.Data = new Data(series2Points);
//
//            //Create List of Series and Add both series to the collection
//            var chartSeries = new List<Series> {series1, series2};
//
//            //Create chart Model
//            var chart1 = new Highcharts("Chart1");
           /* 
            chart1
                .InitChart(new Chart() { DefaultSeriesType = ChartTypes.Line })
                .SetXAxis(new XAxis{Categories = xDataMonths})
                .SetYAxis(new YAxis{})
                .}SetTitle(new Title() { MediaTypeNames.Text = "График поступления денег за Год" })
                .SetSeries(chartSeries.ToArray());

            //pass Chart1Model using ViewBag
            ViewBag.Chart1Model = chart1;*/

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