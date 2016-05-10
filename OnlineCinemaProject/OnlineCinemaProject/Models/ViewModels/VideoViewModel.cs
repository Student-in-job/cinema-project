/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models.ViewModels
{
    public sealed class VideoViewModel
    {
        public VideoViewModel()
        {
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
    
        public ICollection<overview> overviews { get; set; }
        public ICollection<country> countries { get; set; }
        public ICollection<actor> actors { get; set; }
        public ICollection<genre> genres { get; set; }
    }
}*/