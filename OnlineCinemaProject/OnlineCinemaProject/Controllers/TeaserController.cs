using System;
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
    public class TeaserController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        // GET: /Teaser/
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
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "id, name, start,end,showAmount,payment,adv_id")] teaser teaser)
        {
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
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "id,name,start,end,payment, showAmount, adv_id")] teaser teaser)
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
    }
}
