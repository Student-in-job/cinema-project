﻿using System;
<<<<<<< HEAD
using System.Data.Entity;
using System.Security.Claims;
=======
using System.Collections.Generic;
using System.Data.Entity;
>>>>>>> 30c5cc87b3a8b124ad29ee923ca7c917d3abb978
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineCinemaProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public DateTime BirthDay { get; set; }
        public string Email { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext()
            : base("DefaultConnection"/*, throwIfV1Schema: false*/)
        {
           // Database.SetInitializer(new MySqlInitializer());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}