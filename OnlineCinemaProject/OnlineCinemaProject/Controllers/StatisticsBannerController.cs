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
    [Authorize(Roles = "PRManager ")]
    public class StatisticsBannerController : Controller
    {
        private readonly OnlineCinemaEntities db = new OnlineCinemaEntities();
        //public ActionResult Index(){
        // GET: /StatisticsBanner/
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //    var statistics_banner = db.statistics_banner.Include(s => s.aspnetuser).Include(s => s.banner);
            //    return View(statistics_banner.ToList());
            //}

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "id_user_desc" : "";
            ViewBag.DateSortParm = sortOrder == "show_amount" ? "show_amount_desc" : "show_amount";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var statistics_banners = from s in db.statistics_banner
                                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                statistics_banners = statistics_banners.Where(s => s.id_user.ToUpper().Contains(searchString.ToUpper()));

            }
            switch (sortOrder)
            {
                case "id_user_desc":
                    statistics_banners = statistics_banners.OrderByDescending(s => s.id_user);
                    break;
                case "show_amount":
                    statistics_banners = statistics_banners.OrderBy(s => s.show_amount);
                    break;
                case "show_amount_desc":
                    statistics_banners = statistics_banners.OrderByDescending(s => s.show_amount);
                    break;
                case "date":
                    statistics_banners = statistics_banners.OrderBy(s => s.date);
                    break;
                case "date_desc":
                    statistics_banners = statistics_banners.OrderByDescending(s => s.date);
                    break;
                default:  // Name ascending 
                    statistics_banners = statistics_banners.OrderBy(s => s.id_user);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(statistics_banners.ToPagedList(pageNumber, pageSize));
        }




        // GET: /StatisticsBanner/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    statistics_banner statistics_banner = db.statistics_banner.Find(id);
        //    if (statistics_banner == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(statistics_banner);
        //}

        //// GET: /StatisticsBanner/Create
        //public ActionResult Create()
        //{
        //    ViewBag.id_user = new SelectList(db.aspnetusers, "Id", "UserName");
        //    ViewBag.id_banner = new SelectList(db.banners, "id", "name");
        //    return View();
        //}

        //// POST: /StatisticsBanner/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="id,date,show_amount,id_banner,id_user")] statistics_banner statistics_banner)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.statistics_banner.Add(statistics_banner);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.id_user = new SelectList(db.aspnetusers, "Id", "UserName", statistics_banner.id_user);
        //    ViewBag.id_banner = new SelectList(db.banners, "id", "name", statistics_banner.id_banner);
        //    return View(statistics_banner);
        //}

        //// GET: /StatisticsBanner/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    statistics_banner statistics_banner = db.statistics_banner.Find(id);
        //    if (statistics_banner == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.id_user = new SelectList(db.aspnetusers, "Id", "UserName", statistics_banner.id_user);
        //    ViewBag.id_banner = new SelectList(db.banners, "id", "name", statistics_banner.id_banner);
        //    return View(statistics_banner);
        //}

        //// POST: /StatisticsBanner/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="id,date,show_amount,id_banner,id_user")] statistics_banner statistics_banner)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(statistics_banner).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.id_user = new SelectList(db.aspnetusers, "Id", "UserName", statistics_banner.id_user);
        //    ViewBag.id_banner = new SelectList(db.banners, "id", "name", statistics_banner.id_banner);
        //    return View(statistics_banner);
        //}

        //GET: /StatisticsBanner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            statistics_banner statistics_banner = db.statistics_banner.Find(id);
            if (statistics_banner == null)
            {
                return HttpNotFound();
            }
            return View(statistics_banner);
        }

        // POST: /StatisticsBanner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            statistics_banner statistics_banner = db.statistics_banner.Find(id);
            db.statistics_banner.Remove(statistics_banner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }

}