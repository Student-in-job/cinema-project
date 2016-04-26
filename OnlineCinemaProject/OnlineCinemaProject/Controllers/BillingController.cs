using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.ViewModels;
using OnlineCinemaProject.Utils;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "BilingManager")]
    [SuppressMessage("ReSharper", "CoVariantArrayConversion")]
    public class BillingController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        //
        // GET: /tariff/

        public ActionResult Statistics()
        {
            var payments = _db.payments.Where(i => i.payment_date.Year == DateTime.Today.Year).ToList();
            var chartValues = new Dictionary<string, decimal>();

            foreach (var payment in payments)
            {
                var month = DateUtils.GetMonthName(payment.payment_date.Month);
                var amount = payment.amount;
                if (chartValues.ContainsKey(month))
                {
                    chartValues[month] += amount;
                }
                else
                {
                    chartValues.Add(month, amount);
                }
            }

            var chartDatas = chartValues.Keys.Select(value => new PaymentTotal
            {
                MonthName = value,
                Total = chartValues[value]
            }).ToList();

            var xDataMonths = chartValues.Keys.ToArray();
            var yDataCounts = chartDatas.Select(i => new object[] { i.Total }).ToArray();

            var chart2 = new Highcharts("Chart2")
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line,  })
                        
                        .SetTitle(new Title { Text = "Incoming payments per month" })
                        .SetXAxis(new XAxis { Categories = xDataMonths })
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Amount of Money" } })
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return '<b>'+ this.series.name +'</b><br/>'+ this.x +': '+ this.y; }"
                        })
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = false
                            }
                        })
                        .SetSeries(new[]
                    {
                        new Series {Name = "Hour", Data = new Data(yDataCounts)}
                    });

            ViewBag.Chart1Model = chart2;

            return View();
        }


        //
        // GET: /Tariff/
        public ActionResult Tariffs()
        {
            return View(_db.tariffs.ToList());
        }

        //
        // GET: /tariff/Details/5

        public ActionResult Details(int id = 0)
        {
            tariff tariff = _db.tariffs.Find(id);
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
            var tariff = new tariff
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
                _db.tariffs.Add(tariff);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tariffView);
        }

        //
        // GET: /tariff/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tariff tariff = _db.tariffs.Find(id);

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
                _db.Entry(tariff).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
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
        // GET: /tariff/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tariff tariff = _db.tariffs.Find(id);
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
            tariff tariff = _db.tariffs.Find(id);
            _db.tariffs.Remove(tariff);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
       
        

    }
}