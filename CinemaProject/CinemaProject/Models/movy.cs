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
    
    public partial class movy
    {
        public movy()
        {
            this.moviehistories = new HashSet<moviehistory>();
            this.usermovies = new HashSet<UserMovie>();
        }
    
        public int id { get; set; }
        public string url { get; set; }
        public System.DateTime creation_date { get; set; }
        public int video_id { get; set; }
        public float price { get; set; }
        public int quality { get; set; }
    
        public virtual ICollection<moviehistory> moviehistories { get; set; }
        public virtual ICollection<UserMovie> usermovies { get; set; }
        public virtual video video { get; set; }
    }
}
