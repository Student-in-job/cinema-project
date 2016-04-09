using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
     [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        // GET: /User/
        public ActionResult Index()
        {
            var aspnetusers = db.aspnetusers.Include(a => a.tariff);
            //var aspnetroles = db.aspnetroles.ToList();
            //ViewBag.roles = db.aspnetroles.Where(i => i.aspnetusers == aspnetuser).ToList();
            return View(aspnetusers.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnetuser aspnetuser = db.aspnetusers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            return View(aspnetuser);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            ViewBag.TariffId = new SelectList(db.tariffs, "id", "name");
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserName,PasswordHash,SecurityStamp,Discriminator,FirstName,LastName,BirthDate,Email,Sex,JoinDate,Balance,TariffId")] aspnetuser aspnetuser)
        {
            if (ModelState.IsValid)
            {
                db.aspnetusers.Add(aspnetuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TariffId = new SelectList(db.tariffs, "id", "name", aspnetuser.TariffId);
            return View(aspnetuser);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnetuser aspnetuser = db.aspnetusers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.TariffId = new SelectList(db.tariffs, "id", "name", aspnetuser.TariffId);
            return View(aspnetuser);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserName,PasswordHash,SecurityStamp,Discriminator,FirstName,LastName,BirthDate,Email,Sex,JoinDate,Balance,TariffId")] aspnetuser aspnetuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspnetuser).State = EntityState.Modified;
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            ViewBag.TariffId = new SelectList(db.tariffs, "id", "name", aspnetuser.TariffId);
            return View(aspnetuser);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnetuser aspnetuser = db.aspnetusers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            return View(aspnetuser);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            aspnetuser aspnetuser = db.aspnetusers.Find(id);
            db.aspnetusers.Remove(aspnetuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
