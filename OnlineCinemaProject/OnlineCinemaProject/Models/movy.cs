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
    
    public partial class movy
    {
        public movy()
        {
            this.usermovies = new HashSet<usermovy>();
            this.moviehistories = new HashSet<moviehistory>();
        }
    
        public int id { get; set; }
        public string url { get; set; }
        public System.DateTime creation_date { get; set; }
        public int video_id { get; set; }
        public decimal price { get; set; }
        public int quality { get; set; }
    
        public virtual video video { get; set; }
        public virtual ICollection<usermovy> usermovies { get; set; }
        public virtual ICollection<moviehistory> moviehistories { get; set; }
    }
}
