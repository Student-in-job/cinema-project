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
    
    public partial class teaser
    {
        public int id { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
        public int showAmount { get; set; }
        public double payment { get; set; }
        public int adv_id { get; set; }
        public string name { get; set; }
        public string img_url { get; set; }
    
        public virtual advertiser advertiser { get; set; }
    }
}
