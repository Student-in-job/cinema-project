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
    
    public partial class videogenre
    {
        public int id { get; set; }
        public int video_id { get; set; }
        public int genre_id { get; set; }
    
        public virtual genre genre { get; set; }
        public virtual video video { get; set; }
    }
}
