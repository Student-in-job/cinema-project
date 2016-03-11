﻿using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineCinemaProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public int? Sex { get; set; }
        public DateTime? JoinDate { get; set; }
        public decimal? Balance { get; set; }
        public int? SubscriptionId { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection"/*, throwIfV1Schema: false*/)
        {
            Database.SetInitializer(new MySqlInitializer());
        }
    }

    
}