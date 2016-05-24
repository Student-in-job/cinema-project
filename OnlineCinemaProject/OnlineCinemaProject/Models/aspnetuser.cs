//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class aspnetuser
    {
        public aspnetuser()
        {
            this.histories = new HashSet<history>();
            this.purchases = new HashSet<purchase>();
            this.payments = new HashSet<payment>();
            this.episodehistories = new HashSet<episodehistory>();
            this.reviews = new HashSet<review>();
            this.subscriptions = new HashSet<subscription>();
            this.statistics_banner = new HashSet<statistics_banner>();
            this.statistics_teaser = new HashSet<statistics_teaser>();
            this.aspnetroles = new HashSet<aspnetrole>();
            this.userseasons = new HashSet<userseason>();
        }
    
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Discriminator { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Email { get; set; }
        public Nullable<int> Sex { get; set; }
        public Nullable<System.DateTime> JoinDate { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<int> TariffId { get; set; }
        public Nullable<bool> Block { get; set; }
        public Nullable<int> AccountId { get; set; }
    
        public virtual ICollection<history> histories { get; set; }
        public virtual ICollection<purchase> purchases { get; set; }
        public virtual ICollection<payment> payments { get; set; }
        public virtual ICollection<episodehistory> episodehistories { get; set; }
        public virtual ICollection<review> reviews { get; set; }
        public virtual ICollection<subscription> subscriptions { get; set; }
        public virtual tariff tariff { get; set; }
        public virtual ICollection<statistics_banner> statistics_banner { get; set; }
        public virtual ICollection<statistics_teaser> statistics_teaser { get; set; }
        public virtual ICollection<aspnetrole> aspnetroles { get; set; }
        public virtual ICollection<userseason> userseasons { get; set; }
        public virtual account account { get; set; }
    }
}
