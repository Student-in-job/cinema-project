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
    
    public partial class season
    {
        public season()
        {
            this.episodes = new HashSet<episode>();
            this.userseasons = new HashSet<userseason>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public Nullable<System.DateTime> release_date { get; set; }
        public int video_id { get; set; }
    
        public virtual ICollection<episode> episodes { get; set; }
        public virtual ICollection<userseason> userseasons { get; set; }
        public virtual video video { get; set; }
    }
}