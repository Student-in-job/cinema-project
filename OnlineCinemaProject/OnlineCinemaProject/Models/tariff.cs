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
    
    public partial class tariff
    {
        public tariff()
        {
            this.subscriptions = new HashSet<subscription>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime creation_date { get; set; }
        public decimal price { get; set; }
        public bool adverticement_enabled { get; set; }
        public bool new_films_enabled { get; set; }
    
        public virtual ICollection<subscription> subscriptions { get; set; }
    }
}
