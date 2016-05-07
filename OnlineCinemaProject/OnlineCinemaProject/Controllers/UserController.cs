using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using OnlineCinemaProject.Models;









namespace OnlineCinemaProject.Controllers
{
     [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        public UserController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public UserController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

[HttpGet]
         public ActionResult TopUpBalance()
         {
             return View();
         }
         [HttpPost]
         public ActionResult TopUpBalance(TopUpViewModel model)
         {
             aspnetuser user = _db.aspnetusers.Find(model.UserId);
             if (user != null)
             {
                 user.TopUpBalance(model.Amount);
                 payment payment = new payment
                 {
                     aspnetuser = user,
                     amount = model.Amount,
                     title = "Пополнение баланса",
                     payment_type = true,
                     payment_date = DateTime.Now,
                 };
                 _db.payments.Add(payment);
                 _db.Entry(user).State = EntityState.Modified;
                 _db.SaveChanges();
                 ModelState.AddModelError("Ok", "Операция Успешно выполнена!");
                 return View();
             }
             ModelState.AddModelError("Failed", "Неправильо введен Id пользователя.");
             return View(model);
         }

        // GET: /User/
        public ActionResult Index()
        {
            var aspnetusers = _db.aspnetusers.Include(a => a.tariff);
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
            aspnetuser aspnetuser = _db.aspnetusers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            /*ICollection<subscription> subscriptions = db.subscriptions.Where(i =>
                i.tariff == aspnetuser.tariff &&
                i.aspnetuser == aspnetuser
                ).ToList();*/
            ViewBag.subscriptions = _db.subscriptions.Where(i =>
                i.tariff == aspnetuser.tariff &&
                i.aspnetuser == aspnetuser
                ).ToList();
            return View(aspnetuser);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            ViewBag.TariffId = new SelectList(_db.tariffs, "id", "name");
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Email = model.Email,
                    Sex = model.Sex,
                    JoinDate = DateTime.Now,
                    
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "User");
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    AddErrors(result);
                }
                //UpdateRoles(selectedRoles, model);
                //db.Entry(model).State = EntityState.Modified;
                //_db.SaveChanges();
               // return RedirectToAction("Index");
               // return View(model);
            }
            //PopulateIncludedUserData(model);
            return View(model);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnetuser aspnetuser = _db.aspnetusers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.TariffId = new SelectList(_db.tariffs, "id", "name", aspnetuser.TariffId);
            return View(aspnetuser);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserName,PasswordHash,SecurityStamp,Discriminator,FirstName,LastName,BirthDate,Email,Sex,JoinDate,Balance,TariffId,Block")] aspnetuser aspnetuser)
        {
            
           
            if (ModelState.IsValid)
            {
                _db.Entry(aspnetuser).State = EntityState.Modified;
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges
                    _db.SaveChanges();
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
            ViewBag.TariffId = new SelectList(_db.tariffs, "id", "name", aspnetuser.TariffId);
            return View(aspnetuser);
        }

        // GET: /User/Delete/5
        public ActionResult Delete( string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnetuser aspnetuser = _db.aspnetusers.Find(id);
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
            aspnetuser aspnetuser = _db.aspnetusers.Find(id);
            _db.aspnetusers.Remove(aspnetuser);
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

        public ActionResult Profile(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnetuser aspnetuser = _db.aspnetusers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
             
            ICollection<subscription> subscriptions = _db.subscriptions.Where(i =>i.user_id == aspnetuser.Id).ToList();
            ViewBag.subscriptions = subscriptions;
            return View(aspnetuser);
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            //AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


    }
}
