using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProject.Models.ViewModels
{
    public class VideoViewModel
    {
        public VideoViewModel()
        {
            this.likes = new HashSet<like>();
            this.overviews = new HashSet<overview>();
            this.countries = new HashSet<country>();
            this.actors = new HashSet<actor>();
            this.genres = new HashSet<genre>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int age_limit { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime release_date { get; set; }
        [DataType(DataType.MultilineText)]
        public string details { get; set; }
        public string director { get; set; }
        public int type { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    
        public virtual ICollection<like> likes { get; set; }
        public virtual ICollection<overview> overviews { get; set; }
        public virtual ICollection<country> countries { get; set; }
        public virtual ICollection<actor> actors { get; set; }
        public virtual ICollection<genre> genres { get; set; }
    }
}