//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.histories = new HashSet<history>();
            this.likes = new HashSet<like>();
            this.overviews = new HashSet<overview>();
            this.payments = new HashSet<payment>();
        }
    
        public int id { get; set; }
        public string firstname { get; set; }
        public string secondname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public System.DateTime date_of_birth { get; set; }
        public int sex { get; set; }
        public string login { get; set; }
        public double balance { get; set; }
        public Nullable<int> subscription_id { get; set; }
    
        public virtual ICollection<history> histories { get; set; }
        public virtual ICollection<like> likes { get; set; }
        public virtual ICollection<overview> overviews { get; set; }
        public virtual ICollection<payment> payments { get; set; }
        public virtual subscription subscription { get; set; }
    }
}
