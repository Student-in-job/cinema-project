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


namespace CinemaProject.Controllers
{
    [Authorize(Roles = "PRManager ")]
    public class BannerController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        // GET: /Banner/
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "start" ? "start_desc" : "start";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var banners = from s in _db.banners
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                banners = banners.Where(s => s.name.ToUpper().Contains(searchString.ToUpper()));
            
            }
            switch (sortOrder)
            {
                case "name_desc":
                    banners = banners.OrderByDescending(s => s.name);
                    break;
                case "start":
                    banners = banners.OrderBy(s => s.start);
                    break;
                case "start_desc":
                    banners = banners.OrderByDescending(s => s.start);
                    break;
                default:  // Name ascending 
                    banners = banners.OrderBy(s => s.name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(banners.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Banner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner banner = _db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: /Banner/Create
        public ActionResult Create()
        {
           
            //PopulateAdvertisersDropDownList();
            ViewBag.advlist = new SelectList(_db.advertisers, "id", "name");
        //   return View();
            banner banner = new banner
            {
                start = DateTime.Now
            };
            return View(banner);

        }

       

        // POST: /Banner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "id, name, start, end, payment, adv_id")] banner banner)
        {
            banner.show_amount = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                              + file.FileName);
                        banner.img_url = file.FileName;
                    }
                    _db.banners.Add(banner);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator. \n" + dex.Message );
            }
        //    PopulateAdvertisersDropDownList(banner.adv_id); 
            ViewBag.advlist = new SelectList(_db.advertisers, "id", "name");
            return View(banner);
        }

       


        // GET: /Banner/Edit/5
        public ActionResult Edit(int? id)
        {
            
            banner banner = _db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
           ViewBag.advlist = new SelectList(_db.advertisers, "id", "name");
            return View(banner);
        }

        // POST: /Banner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include="id,name,start,end,payment,adv_id")] banner banner)
        {
            //UpdateVideoGenres(selectedGenres, banner);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                          + file.FileName);
                    banner.img_url = file.FileName;
                }
                _db.Entry(banner).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banner);
        }

        // GET: /Banner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner banner = _db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: /Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            banner banner = _db.banners.Find(id);
            _db.banners.Remove(banner);
            _db.SaveChanges();
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

        public ActionResult Rotator() 
        {
            
            // string token = "c2e50aec-ab00-493c-9fec-1770fe663d4b";
            //IEnumerable<string> headerValues;
            //var id_user = string.Empty;
            //if (Request.Headers.TryGetValues("token", out headerValues))
            //{
            //    id_user = headerValues.FirstOrDefault();
            //}
            //SELECT banners.img_url statistics_banner from banners where banners.id not in (SELECT statistics_banner.id_banner from statistics_banner WHERE statistics_banner.id_user = '9e0cc9f5-0665-49d4-a009-4c859a00b2d9') 

            //string query = "SELECT * FROM banners order by show_amount asc";
            string query = "SELECT * FROM banners where active = '1' order by show_amount asc";
            var banner = _db.banners.SqlQuery(query).ToList().First();
            statistics_banner sb = new statistics_banner();
            try
            {
                sb = _db.statistics_banner.Single(i => i.id_banner == banner.id);
            }
            catch (Exception e)
            {
                //e.Data;
            };
            

            _db.banners.Attach(banner);
            banner.show_amount = banner.show_amount + 1;
            var entry = _db.Entry(banner);
            entry.Property(e => e.show_amount).IsModified = true;
            // other changed properties
            _db.SaveChanges();

            if (sb.banner!= null) {

                        _db.statistics_banner.Attach(sb);
                        sb.date = DateTime.Now;
                        sb.show_amount = (int?) banner.show_amount;
                       
                    var entry1 = _db.Entry(sb);
                        entry1.Property(e => e.show_amount).IsModified = true;
                        entry1.Property(e => e.date).IsModified = true;
                        // other changed properties
                        _db.SaveChanges();
                                      }
            else
            {
                sb = new statistics_banner();
                sb.date = DateTime.Now;
                sb.id_banner = banner.id;
                sb.show_amount = (int?) banner.show_amount;
                sb.id_user = "c2e50aec-ab00-493c-9fec-1770fe663d4b";
                _db.statistics_banner.Add(sb);
                _db.SaveChanges();
                
            }
            
            return View(banner);

           
        }
        
    }
}
