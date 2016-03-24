using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
    public class LoginApiController : ApiController
    {

         private OnlineCinemaEntities db = new OnlineCinemaEntities();

        public LoginApiController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public LoginApiController(UserManager<ApplicationUser> userManager)
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
        public String Post([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =  UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    
                    return user.Id;
                }
            }


            return "error";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}