﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using OnlineCinemaProject.Models;



namespace OnlineCinemaProject.Controllers.Api
{
    public class RegistrationApiController : ApiController
    {
         private OnlineCinemaEntities db = new OnlineCinemaEntities();

        public RegistrationApiController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }
         public RegistrationApiController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        // POST api/<controller>
        public async Task<string> Post([FromBody]RegisterViewModel model)
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
                    Block = false,
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "User");
                    account account = new account
                    {
                        balance = 0
                    };

                    // vanya eto ya dobavil ramazan 
                    db.accounts.Add(account);
                    db.SaveChanges();

                    var aspnetuser = db.aspnetusers.Find(user.Id);
                    aspnetuser.account = account;
                    db.Entry(aspnetuser).State = EntityState.Modified;
                    db.SaveChanges();
                   // await SignInAsync(user, isPersistent: false);
                    return user.Id;
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return null;
           
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
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