using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
// ReSharper disable All

namespace OnlineCinemaProject.Models.ViewModels
{
    public class OverviewModel
    {
        [Required]
        public int video_id { get; set; }
        [Required]
        public string user_id { get; set; }
        [Required]
        public float rating { get; set; }
        public string comment { get; set; }
    }
}