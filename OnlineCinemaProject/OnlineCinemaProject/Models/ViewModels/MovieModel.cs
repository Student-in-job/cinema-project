using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models.ViewModels
{
    public class MovieModel
    {
        public int id { get; set; }
        
        [Required]
        public string url { get; set; }

        public int quality { get; set; }

        public DateTime creation_date { get; set; }
        
        [Required]
        public decimal price { get; set; }
        
    }
}