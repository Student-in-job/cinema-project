using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineCinemaProject.Models;
using PagedList;
using System.Collections.Generic;
using System.Web;


namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "PRManager, Advertiser")]
    public class AdvertiserController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        // GET: /Advertiser/
        [Authorize(Roles = "PRManager")]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "email" ? "email_desc" : "email";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var advertisers = from s in _db.advertisers
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                advertisers = advertisers.Where(s => s.name.ToUpper().Contains(searchString.ToUpper())
                                       || s.email.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    advertisers = advertisers.OrderByDescending(s => s.name);
                    break;
                case "email":
                    advertisers = advertisers.OrderBy(s => s.email);
                    break;
                case "email_desc":
                    advertisers = advertisers.OrderByDescending(s => s.email);
                    break;
                default:  // Name ascending 
                    advertisers = advertisers.OrderBy(s => s.name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(advertisers.ToPagedList(pageNumber, pageSize));
        }




        // GET: /Advertiser/Details/5
        [Authorize(Roles = "PRManager")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            advertiser advertiser = _db.advertisers.Find(id);
            if (advertiser == null)
            {
                return HttpNotFound();
            }
            return View(advertiser);
        }

        // GET: /Advertiser/Create
        [Authorize(Roles = "PRManager")]
        public ActionResult Create()
        { 
           
            return View();
        }

        // POST: /Advertiser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PRManager")]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "id,name,email,phone_number,password")] advertiser advertiser)
        {
           
            //if (ModelState.IsValid)
            //{
            //    _db.advertisers.Add(advertiser);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                              + file.FileName);
                        advertiser.img_url = file.FileName;
                    }
                    _db.advertisers.Add(advertiser);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator. \n" + dex.Message);
            }

            return View(advertiser);
        }

        // GET: /Advertiser/Edit/5
        [Authorize(Roles = "PRManager, Advertiser")]
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            advertiser advertiser = _db.advertisers.Find(id);
            if (advertiser == null)
            {
                return HttpNotFound();
            }
            return View(advertiser);
        }

        // POST: /Advertiser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PRManager, Advertiser")]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "id,name,email,phone_number,password")] advertiser advertiser)
        {
          
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/") + file.FileName);
                    advertiser.img_url = file.FileName;
                }
                _db.Entry(advertiser).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertiser);
        }

        // GET: /Advertiser/Delete/5
        [Authorize(Roles = "PRManager")]
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            advertiser advertiser = _db.advertisers.Find(id);
            if (advertiser == null)
            {
                return HttpNotFound();
            }
            return View(advertiser);
        }
        
        // POST: /Advertiser/Delete/5
       [HttpPost]
       [ValidateAntiForgeryToken]
       [Authorize(Roles = "PRManager")]
public ActionResult Delete(int id)
{
    try
    {
        advertiser advertiser = _db.advertisers.Find(id);
        _db.advertisers.Remove(advertiser);
        _db.SaveChanges();
    }
    catch (DataException/* dex */)
    {
        // uncomment dex and log error. 
        return RedirectToAction("Delete", new {id, saveChangesError = true });
    }
    return RedirectToAction("Index");
}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Users = "advertiser")]
        public ActionResult Personal_account(int id)
        {
            var allStatistcs = _db.statistics_banner;
            var banners = _db.banners.Where(i=>i.adv_id == id);
            var advStatistics = from a in allStatistcs join b in banners on a.id_banner equals b.id select a;
           

            var allStatistcs2 = _db.statistics_teaser;
            var teasers = _db.teasers.Where(i => i.adv_id == id);
            var advStatistics2 = from n in allStatistcs2 join t in teasers on n.id_teasers equals t.id select n;
             
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            advertiser advertiser = _db.advertisers.Find(id);
            if (advertiser == null)
            {
                return HttpNotFound();
            }

             ViewBag.statistics = advStatistics.ToList();
            ViewBag.statistics2 = advStatistics2.ToList();
            return View(advertiser);
        }

        [Authorize(Users = "advertiser")]
        public ActionResult TeaserStatistics(int id)
        {
            return View(_db.statistics_teaser.Where(i => i.id_teasers == id).ToList());
        }

        [Authorize(Users = "advertiser")]
        public ActionResult BannerStatistics(int id)
        {
            return View(_db.statistics_banner.Where(i => i.id_banner == id).ToList());
        }

        [Authorize(Users = "advertiser")]
        [HttpPost]
        public ActionResult ActivateBanners(int id, List<int> args)
        {
            var banners = _db.banners.Where(i => i.adv_id == id).ToList();
            int counter = 0;
            foreach (var banner in banners)
            {
                banner.active = false;
                if (args != null)
                {
                    foreach (var i in args)
                    {
                        if (banner.id == i)
                        {
                            banner.active = true;
                        }
                    }
                }
                _db.Entry(banner).State = EntityState.Modified;
                _db.SaveChanges();

            }
            return Json(true);
        }

        [Authorize(Users = "advertiser")]
        public ActionResult ActivateTeasers(int id, List<int> args)
        {
            var teasers = _db.teasers.Where(i => i.adv_id == id).ToList();
            int counter = 0;
            foreach (var teaser in teasers)
            {
                teaser.active = false;
                if (args != null)
                {
                    foreach (var i in args)
                    {
                        if (teaser.id == i)
                        {
                            teaser.active = true;
                        }
                    }
                }
                _db.Entry(teaser).State = EntityState.Modified;
                _db.SaveChanges();

            }
            return Json(true);
        }
      
      } 

}    