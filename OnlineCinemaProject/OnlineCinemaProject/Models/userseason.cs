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
    
    public partial class userseason
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public int season_id { get; set; }
        public decimal payment { get; set; }
        public System.DateTime purchase_date { get; set; }
    
        public virtual aspnetuser aspnetuser { get; set; }
        public virtual season season { get; set; }
    }
}