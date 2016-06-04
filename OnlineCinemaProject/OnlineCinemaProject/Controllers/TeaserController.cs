using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineCinemaProject.Models;
using PagedList;


namespace OnlineCinemaProject.Controllers
{
   [Authorize(Roles = "PRManager, Advertiser")]
    public class TeaserController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        // GET: /Teaser/
         [Authorize(Roles = "PRManager")]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "start" ? "start_desc" : "start";
            ViewBag.EmailSortParm = sortOrder == "payment" ? "payment_desc" : "payment";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var teasers = from s in _db.teasers
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                teasers = teasers.Where(s => s.name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    {
                        teasers = teasers.OrderByDescending(s => s.name);
                        break;
                    }
                case "start":
                    {
                        teasers = teasers.OrderBy(s => s.start);
                        break;
                    }
                case "start_desc":
                    {
                        teasers = teasers.OrderByDescending(s => s.start);
                        break;
                    }
                case "payment":
                    {
                        teasers = teasers.OrderBy(s => s.payment);
                        break;
                    }
                case "payment_desc":
                    {
                        teasers = teasers.OrderByDescending(s => s.payment);
                        break;
                    }

                default:  // Name ascending 
                    teasers = teasers.OrderBy(s => s.name);
                    break;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(teasers.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Teaser/Details/5
         [Authorize(Roles = "PRManager")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teaser teaser = _db.teasers.Find(id);
            if (teaser == null)
            {
                return HttpNotFound();
            }
            return View(teaser);
        }

        // GET: /Teaser/Create
         [Authorize(Roles = "PRManager, Advertiser")]
        public ActionResult Create()
        {

            //PopulateAdvertisersDropDownList();
            ViewBag.advlist = new SelectList(_db.advertisers, "id", "name");
            //   return View();
            teaser teaser = new teaser
            {
                start = DateTime.Now
            };
            return View(teaser);

        }

        // POST: /Teaser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PRManager, Advertiser")]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "id, name, start,end,showAmount,payment, url, adv_id")] teaser teaser)
         {
             teaser.showAmount = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                              + file.FileName);
                        teaser.img_url = file.FileName;
                    }
                    _db.teasers.Add(teaser);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator. \n" + dex.Message);
            }
            //    PopulateAdvertisersDropDownList(banner.adv_id); 
            ViewBag.advlist = new SelectList(_db.advertisers, "id", "name");
            return View(teaser);
        }

        // GET: /Teaser/Edit/5
         [Authorize(Roles = "PRManager")]
        public ActionResult Edit(int? id)
         {
             
            teaser teaser = _db.teasers.Find(id);
            if (teaser == null)
            {
                return HttpNotFound();
            }
            ViewBag.advlist = new SelectList(_db.advertisers, "id", "name");
            return View(teaser);
        }

        // POST: /Banner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PRManager")]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "id,name,start,end,payment, showAmount,url, adv_id")] teaser teaser)
        {
            //UpdateVideoGenres(selectedGenres, banner);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/uploads/")
                                                          + file.FileName);
                    teaser.img_url = file.FileName;
                }
                _db.Entry(teaser).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teaser);
        }

        // GET: /Teaser/Delete/5
         [Authorize(Roles = "PRManager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teaser teaser = _db.teasers.Find(id);
            if (teaser == null)
            {
                return HttpNotFound();
            }
            return View(teaser);
        }

        // POST: /Teaser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PRManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            teaser teaser = _db.teasers.Find(id);
            _db.teasers.Remove(teaser);
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
         [Authorize(Roles = "PRManager")]
        public ActionResult Rotator()
        {
            OnlineCinemaEntities db = new OnlineCinemaEntities();
            // string token = "c2e50aec-ab00-493c-9fec-1770fe663d4b";
            //IEnumerable<string> headerValues;
            //var id_users = string.Empty;
            //if (Request.Headers.TryGetValues("token", out headerValues))
            //{
            //    id_users = headerValues.FirstOrDefault();
            //}
            //SELECT teasers.img_url statistics_teaser from teasers where teasers.id not in (SELECT statistics_teaser.id_teaser from statistics_teaser WHERE statistics_teaser.id_users = '9e0cc9f5-0665-49d4-a009-4c859a00b2d9') 
            string query = "SELECT * FROM teaser where active = '1' order by showAmount asc";
            var teaser = db.teasers.SqlQuery(query).ToList().First();
            if (teaser.showAmount == null)
            {
                teaser.showAmount = 0;
            }
            statistics_teaser sb = new statistics_teaser();
            try
            {
                sb = db.statistics_teaser.Single(i => i.id_teasers == teaser.id);
            } catch(Exception e) {

            };
            db.teasers.Attach(teaser);
            teaser.showAmount = teaser.showAmount + 1;
            var entry = db.Entry(teaser);
            entry.Property(e => e.showAmount).IsModified = true;
            // other changed properties
            db.SaveChanges();

            if (sb.teaser != null)
            {

                db.statistics_teaser.Attach(sb);
                sb.dateShow = DateTime.Now;
                sb.showAmount = (int?) teaser.showAmount;
                var entry1 = db.Entry(sb);
                entry1.Property(e => e.showAmount).IsModified = true;
                entry1.Property(e => e.dateShow).IsModified = true;
                // other changed properties
                db.SaveChanges();
            }
            else
            {
                sb = new statistics_teaser();
                sb.dateShow = DateTime.Now;
                sb.id_teasers = teaser.id;
                sb.showAmount = (int?) teaser.showAmount;
                sb.id_users = User.Identity.GetUserId();
                db.statistics_teaser.Add(sb);
                db.SaveChanges();

            }

            return View(teaser);


        }

    }
}
