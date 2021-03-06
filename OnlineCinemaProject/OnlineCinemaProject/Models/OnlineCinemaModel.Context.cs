﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineCinemaProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineCinemaEntities : DbContext
    {
        public OnlineCinemaEntities()
            : base("name=OnlineCinemaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actor> actors { get; set; }
        public virtual DbSet<advertiser> advertisers { get; set; }
        public virtual DbSet<aspnetrole> aspnetroles { get; set; }
        public virtual DbSet<aspnetuser> aspnetusers { get; set; }
        public virtual DbSet<banner> banners { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<episodehistory> episodehistories { get; set; }
        public virtual DbSet<file> files { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<history> histories { get; set; }
        public virtual DbSet<manufacturer> manufacturers { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<purchase> purchases { get; set; }
        public virtual DbSet<review> reviews { get; set; }
        public virtual DbSet<season> seasons { get; set; }
        public virtual DbSet<statistics_banner> statistics_banner { get; set; }
        public virtual DbSet<statistics_teaser> statistics_teaser { get; set; }
        public virtual DbSet<subscription> subscriptions { get; set; }
        public virtual DbSet<tariff> tariffs { get; set; }
        public virtual DbSet<teaser> teasers { get; set; }
        public virtual DbSet<videoactor> videoactors { get; set; }
        public virtual DbSet<videogenre> videogenres { get; set; }
        public virtual DbSet<video> videos { get; set; }
        public virtual DbSet<userseason> userseasons { get; set; }
        public virtual DbSet<backup> backups { get; set; }
        public virtual DbSet<account> accounts { get; set; }
    }
}
