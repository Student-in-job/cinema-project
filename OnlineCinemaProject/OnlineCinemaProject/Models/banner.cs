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
    
    public partial class banner
    {
        public banner()
        {
            this.statistics_banner = new HashSet<statistics_banner>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> start { get; set; }
        public Nullable<System.DateTime> end { get; set; }
        public Nullable<double> payment { get; set; }
        public Nullable<int> adv_id { get; set; }
        public string name { get; set; }
        public string img_url { get; set; }
        public Nullable<long> show_amount { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual advertiser advertiser { get; set; }
        public virtual ICollection<statistics_banner> statistics_banner { get; set; }
    }
}
