using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.ViewModels;
using OnlineCinemaProject.Utils;
using Point = DotNet.Highcharts.Options.Point;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "BilingManager")]
    [SuppressMessage("ReSharper", "CoVariantArrayConversion")]
    [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
    public class BillingController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        //
        // GET: /tariff/

        public ActionResult Statistics()
        {
            ViewBag.Clients = _db.aspnetusers.Count();
            ViewBag.Income = Utils.Utils.GetIncome(_db.payments.ToList());
            ViewBag.Account = Utils.Utils.GetAccount(_db.aspnetusers.ToList());
            
            ViewBag.MoneyIncomes = MoneyIncomes();
            ViewBag.Subscribers = Subscribers();
            ViewBag.TariffIncomes = TariffIncomes();

            return View(_db.payments.ToList());
        }


        //
        // GET: /Tariff/
        public ActionResult Tariffs()
        {
            ViewBag.Subscribers = Subscribers();
            ViewBag.TariffIncomes = Subscribers();
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
        public ActionResult Create(TariffViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreationDate = DateTime.Now;
                model.Active = true;
                var tariff = new tariff
                {
                    name = model.Name,
                    description = model.Description,
                    creation_date = model.CreationDate,
                    active = model.Active,
                    adverticement_enabled = model.AdverticementEnabled,
                    new_films_enabled = model.NewFilmsEnabled,
                    price = model.Price
                };
                _db.tariffs.Add(tariff);
                _db.SaveChanges();
                return RedirectToAction("Tariffs");
            }

            return View(model);
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
                // ReSharper disable once PossibleInvalidOperationException
                CreationDate = (DateTime) tariff.creation_date,
                AdverticementEnabled = (bool) tariff.adverticement_enabled,
                NewFilmsEnabled = (bool) tariff.new_films_enabled,
                Price = (decimal) tariff.price,
                Subscriptions = tariff.subscriptions,
                Active = tariff.active
            };
            return View(tariffView);
        }

        //
        // POST: /tariff/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TariffViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tariff = new tariff
                {
                    id = (int) model.Id,
                    name = model.Name,
                    description = model.Description,
                    creation_date = model.CreationDate,
                    active = model.Active,
                    adverticement_enabled = model.AdverticementEnabled,
                    new_films_enabled = model.NewFilmsEnabled,
                    price = model.Price,
                };

                _db.Entry(tariff).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Tariffs");
            }

            return View(model);
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
            return RedirectToAction("Tariffs");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        public Highcharts MoneyIncomes()
        {

            var payments = _db.payments.Where(i => i.payment_date.Year == DateTime.Today.Year).ToList();
            var incomesDictionary = new Dictionary<string, decimal>();

            foreach (var payment in payments)
            {
                var month = Utils.Utils.GetMonthName(payment.payment_date.Month);
                var amount = payment.amount;
                if (incomesDictionary.ContainsKey(month))
                {
                    incomesDictionary[month] += amount;
                }
                else
                {
                    incomesDictionary.Add(month, amount);
                }
            }
            var chartDatas = incomesDictionary.Keys.Select(value => new PaymentTotal
            {
                MonthName = value,
                Total = incomesDictionary[value]
            }).ToList();

            var xDataMonths = incomesDictionary.Keys.ToArray();
            var yDataCounts = chartDatas.Select(i => new object[] { i.Total }).ToArray();

            var chart2 = new Highcharts("Chart2")
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, })

                        .SetTitle(new Title { Text = "Поступления денег на счета пользователей за " + DateTime.Now.Year + " год." })
                        .SetXAxis(new XAxis { Categories = xDataMonths })
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Кол-во денег" } })
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
                        new Series {Name = "Кол-во денег", Data = new Data(yDataCounts)}
                    });
            return chart2;
        }

        public Highcharts Subscribers()
        {
            var tariffs = _db.tariffs.ToList();

            decimal total = tariffs.Aggregate<tariff, decimal>(0, (current, item) => current + item.subscriptions.Count);

            var subscribersChart = tariffs.ToDictionary(tariff => tariff.name, tariff => tariff.subscriptions.Count / total);

            var subscribers = subscribersChart.Keys.Select(value => new PaymentTotal
            {
                MonthName = value,
                Total = subscribersChart[value]
            }).ToList();

            var data = subscribers.Select(i => new object[] {i.MonthName, i.Total }).ToArray();
            
            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { PlotShadow = false })
                .SetTitle(new Title { Text = "Процент подписок на тарифные планы" })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        Cursor = Cursors.Pointer,
                        DataLabels = new PlotOptionsPieDataLabels
                        {
                            Color = ColorTranslator.FromHtml("#000000"),
                            ConnectorColor = ColorTranslator.FromHtml("#000000"),
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "tariff",
                    Data = new Data(data)
                });

            return chart;
        }

        public Highcharts TariffIncomes()
        {
            var tariffs = _db.tariffs.ToList();

            decimal total = tariffs.Aggregate<tariff, decimal>(0, (current, item) => current + item.price.Value*item.subscriptions.Count);

            var subscribersChart = tariffs.ToDictionary(tariff => tariff.name, tariff => tariff.subscriptions.Count*tariff.price / total);

            var subscribers = subscribersChart.Keys.Select(value => new PaymentTotal
            {
                MonthName = value,
                Total = (decimal) subscribersChart[value]
            }).ToList();

            var data = subscribers.Select(i => new object[] { i.MonthName, i.Total }).ToArray();

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { PlotShadow = false })
                .SetTitle(new Title { Text = "Процент подписок на тарифные планы" })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        Cursor = Cursors.Pointer,
                        DataLabels = new PlotOptionsPieDataLabels
                        {
                            Color = ColorTranslator.FromHtml("#000000"),
                            ConnectorColor = ColorTranslator.FromHtml("#000000"),
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "tariff",
                    Data = new Data(data)
                });

            return chart;
        }



    }
}