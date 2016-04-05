using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

[HttpGet]
         public ActionResult TopUpBalance()
         {
             return View();
         }
         [HttpPost]
         public ActionResult TopUpBalance(TopUpViewModel model)
         {
             aspnetuser user = db.aspnetusers.Find(model.UserId);
             if (user != null)
             {
                 user.TopUpBalance(model.Amount);
                 payment payment = new payment
                 {
                     aspnetuser = user,
                     amount = model.Amount,
                     title = "���������� �������",
                     payment_type = true,
                     payment_date = DateTime.Now,
                 };
                 db.payments.Add(payment);
                 db.Entry(user).State = EntityState.Modified;
                 db.SaveChanges();
                 ModelState.AddModelError("Ok", "�������� ������� ���������!");
                 return View();
             }
             ModelState.AddModelError("Failed", "���������� ������ Id ������������.");
             return View(model);
         }

        // GET: /User/
        public ActionResult Index()
        {
            var aspnetusers = db.aspnetusers.Include(a => a.tariff);
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
            /*ICollection<subscription> subscriptions = db.subscriptions.Where(i =>
                i.tariff == aspnetuser.tariff &&
                i.aspnetuser == aspnetuser
                ).ToList();*/
            ViewBag.subscriptions = db.subscriptions.Where(i =>
                i.tariff == aspnetuser.tariff &&
                i.aspnetuser == aspnetuser
                ).ToList();
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
                db.SaveChanges();
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

public ActionResult Profile(string id)
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
             
             ICollection<subscription> subscriptions = db.subscriptions.Where(i =>i.user_id == aspnetuser.Id).ToList();
             ViewBag.subscriptions = subscriptions;
             return View(aspnetuser);
         }

    }
}
