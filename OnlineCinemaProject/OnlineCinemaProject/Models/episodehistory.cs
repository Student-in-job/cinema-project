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
    
    public partial class episodehistory
    {
        public int id { get; set; }
        public int episode_id { get; set; }
        public string user_id { get; set; }
        public string watching_date { get; set; }
    
        public virtual aspnetuser aspnetuser { get; set; }
        public virtual episode episode { get; set; }
    }
}
