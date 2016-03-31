using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        public ApplicationDbContext Context = new ApplicationDbContext();
        //
        // GET: /Role/
        public ActionResult Index()
        {
            var roles = Context.Roles.ToList();
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                Context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                Context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string roleName)
        {
            var thisRole = Context.Roles.FirstOrDefault(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            Context.Roles.Remove(thisRole);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string roleName)
        {
            var thisRole = Context.Roles.FirstOrDefault(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                Context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ManageUserRoles()
        {
            // prepopulat roles for the view dropdown
            var list = Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string userName, string roleName)
        {
            ApplicationUser user = Context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
            var account = new AccountController();
            if (user != null) account.UserManager.AddToRole(user.Id, roleName);

            ViewBag.ResultMessage = "Role created successfully !";

            // prepopulat roles for the view dropdown
            var list = Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                ApplicationUser user = Context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
                var account = new AccountController();

                if (user != null) ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var list = Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string userName, string roleName)
        {
            var account = new AccountController();
            ApplicationUser user = Context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));

            if (user != null && account.UserManager.IsInRole(user.Id, roleName))
            {
                account.UserManager.RemoveFromRole(user.Id, roleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            // prepopulat roles for the view dropdown
            var list = Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }
    }
}