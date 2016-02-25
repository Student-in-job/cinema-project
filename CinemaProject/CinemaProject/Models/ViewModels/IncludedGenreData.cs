using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaProject.Models.ViewModels
{
    public class IncludedGenreData
    {
        public int id { get; set; }
        public string Title { get; set; }
        public bool Included { get; set; }
    }
}