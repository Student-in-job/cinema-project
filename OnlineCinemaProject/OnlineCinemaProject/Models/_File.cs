using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// ReSharper disable All

namespace OnlineCinemaProject.Models
{
    public partial class file
    {
        public const int HD = 2;
        public const int SD = 1;

        public string getPurchaseTitle()
        {
            if (video.type == video.SERIAL)
            {
                return "Покупка" + season_id + "-го сезона, сериала " + video.name;
            }

            return "Покупка фильма " + video.name;

        }

    }

    public class FileInfo
    {
        public int id { get; set; }
        public decimal? price { get; set; }
        public int? quality { get; set; }
        public string url { get; set; }
    }

    public class SeasonInfo
    {
        public int id { get; set; }
        public int season_number { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }

        public List<EpisodeInfo> episodes { get; set; }
    }

    public class EpisodeInfo
    {
        public int id { get; set; }
        public int? quality { get; set; }
        public string url { get; set; }
        public int? episode_number { get; set; }
        public string title { get; set; }
    }
    public class TrailerInfo
    {
        public int id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
    }
}