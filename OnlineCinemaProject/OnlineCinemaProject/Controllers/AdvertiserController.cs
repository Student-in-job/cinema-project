using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineCinemaProject.Models;
using PagedList;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "PRManager")]
    public class AdvertiserController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        // GET: /Advertiser/
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Advertiser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,email,phone_number")] advertiser advertiser)
        {
            if (ModelState.IsValid)
            {
                _db.advertisers.Add(advertiser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertiser);
        }

        // GET: /Advertiser/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: /Advertiser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,email,phone_number")] advertiser advertiser)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(advertiser).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertiser);
        }

        // GET: /Advertiser/Delete/5
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
    }
}
