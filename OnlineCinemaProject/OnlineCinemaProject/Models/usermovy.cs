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
    
    public partial class usermovy
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public int movie_id { get; set; }
        public int payment_id { get; set; }
    
        public virtual movy movy { get; set; }
        public virtual payment payment { get; set; }
        public virtual aspnetuser aspnetuser { get; set; }
    }
}
