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
    
    public partial class statistics_banner
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> show_amount { get; set; }
        public Nullable<int> id_banner { get; set; }
        public string id_user { get; set; }
    
        public virtual aspnetuser aspnetuser { get; set; }
        public virtual banner banner { get; set; }
    }
}
