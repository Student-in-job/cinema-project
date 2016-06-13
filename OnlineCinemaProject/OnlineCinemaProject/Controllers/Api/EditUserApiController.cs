using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    
    public class EditUserApiController : ApiController
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();
        // GET api/edituserapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/edituserapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/edituserapi
        public string Post([Bind(Include = "UserName,FirstName,LastName,BirthDate,Email,Sex,TariffId")] aspnetuser aspnetuser)
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
                return "Successfull";
            }
            
            return "Error";
        }

        // PUT api/edituserapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/edituserapi/5
        public void Delete(int id)
        {
        }
    }
}
