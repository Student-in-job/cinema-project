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
    
    public partial class subscription
    {
        public subscription()
        {
            this.aspnetusers = new HashSet<aspnetuser>();
        }
    
        public int id { get; set; }
        public int tariff_id { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
        public double payment { get; set; }
    
        public virtual ICollection<aspnetuser> aspnetusers { get; set; }
        public virtual tariff tariff { get; set; }
    }
}
