using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineCinemaProject.Models;
using PagedList;


namespace OnlineCinemaProject.Controllers
{
    public class StatisticsTeaserController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        // GET: /StatisticsTeaser/
        //public ActionResult Index()
        //{
        //    var statistics_teaser = db.statistics_teaser.Include(s => s.aspnetuser).Include(s => s.teaser);
        //    return View(statistics_teaser.ToList());
        //}


        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "id_users_desc" : "";
            ViewBag.DateShowSortParm = sortOrder == "showAmount" ? "showAmount_desc" : "showAmount";
            ViewBag.DateShowSortParm = sortOrder == "dateShow" ? "dateShow_desc" : "dateShow";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var statistics_teasers = from s in db.statistics_teaser
                                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                statistics_teasers = statistics_teasers.Where(s => s.id_users.ToUpper().Contains(searchString.ToUpper()));

            }
            switch (sortOrder)
            {
                case "id_users_desc":
                    statistics_teasers = statistics_teasers.OrderByDescending(s => s.id_users);
                    break;
                case "showAmount":
                    statistics_teasers = statistics_teasers.OrderBy(s => s.showAmount);
                    break;
                case "showAmount_desc":
                    statistics_teasers = statistics_teasers.OrderByDescending(s => s.showAmount);
                    break;
                case "dateShow":
                    statistics_teasers = statistics_teasers.OrderBy(s => s.dateShow);
                    break;
                case "dateShow_desc":
                    statistics_teasers = statistics_teasers.OrderByDescending(s => s.dateShow);
                    break;
                default:  // Name ascending 
                    statistics_teasers = statistics_teasers.OrderBy(s => s.id_users);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(statistics_teasers.ToPagedList(pageNumber, pageSize));
        }





        // GET: /StatisticsTeaser/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    statistics_teaser statistics_teaser = db.statistics_teaser.Find(id);
        //    if (statistics_teaser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(statistics_teaser);
        //}

        // GET: /StatisticsTeaser/Create
        //public ActionResult Create()
        //{
        //    ViewBag.id_users = new SelectList(db.aspnetusers, "Id", "UserName");
        //    ViewBag.id_teasers = new SelectList(db.teasers, "id", "name");
        //    return View();
        //}

        //// POST: /StatisticsTeaser/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="id,id_teasers,id_users,showAmount,dateShow")] statistics_teaser statistics_teaser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.statistics_teaser.Add(statistics_teaser);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.id_users = new SelectList(db.aspnetusers, "Id", "UserName", statistics_teaser.id_users);
        //    ViewBag.id_teasers = new SelectList(db.teasers, "id", "name", statistics_teaser.id_teasers);
        //    return View(statistics_teaser);
        //}

        //// GET: /StatisticsTeaser/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    statistics_teaser statistics_teaser = db.statistics_teaser.Find(id);
        //    if (statistics_teaser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.id_users = new SelectList(db.aspnetusers, "Id", "UserName", statistics_teaser.id_users);
        //    ViewBag.id_teasers = new SelectList(db.teasers, "id", "name", statistics_teaser.id_teasers);
        //    return View(statistics_teaser);
        //}

        //// POST: /StatisticsTeaser/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="id,id_teasers,id_users,showAmount,dateShow")] statistics_teaser statistics_teaser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(statistics_teaser).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.id_users = new SelectList(db.aspnetusers, "Id", "UserName", statistics_teaser.id_users);
        //    ViewBag.id_teasers = new SelectList(db.teasers, "id", "name", statistics_teaser.id_teasers);
        //    return View(statistics_teaser);
        //}

        //// GET: /StatisticsTeaser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            statistics_teaser statistics_teaser = db.statistics_teaser.Find(id);
            if (statistics_teaser == null)
            {
                return HttpNotFound();
            }
            return View(statistics_teaser);
        }

        // POST: /StatisticsTeaser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            statistics_teaser statistics_teaser = db.statistics_teaser.Find(id);
            db.statistics_teaser.Remove(statistics_teaser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}
