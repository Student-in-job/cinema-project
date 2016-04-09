using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models
{
    public class StatisticBanner : banner
    {
      
        public int sbid { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> show_amount { get; set; }
        public Nullable<int> id_banner { get; set; }
        public string id_user { get; set; }

        public virtual aspnetuser aspnetuser { get; set; }
        public virtual banner banner { get; set; }
    }
}