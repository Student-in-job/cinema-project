using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Hosting;
using FluentScheduler;
using OnlineCinemaProject.Models.ViewModels;

namespace OnlineCinemaProject.Models
{
    public class ScoreCallculationJob:IJob, IRegisteredObject
    {
        public static int Interval = 10;
        public static int MinimalVoteLimit = 10;
        private readonly object _lock = new object();

        private bool _shuttingDown;

        public ScoreCallculationJob()
        {
            HostingEnvironment.RegisterObject(this);
        }

        public void Execute()
        {
            lock (_lock)
            {
                if (_shuttingDown)
                    return;
                using (var context = new OnlineCinemaEntities())
                {
                    var checkTime = DateTime.Now.AddMinutes(-Interval);
                    var videoToUpdate =
                        context.videos.Where(
                            video => (!video.last_score_calc.HasValue || video.last_score_calc < checkTime) && video.reviews.Any(o => o.creation_date > video.last_score_calc)).ToList();
                    foreach (var video in videoToUpdate)
                    {
                        video.score = GetVideoScore(video, context);
                    }
                    foreach (var video in videoToUpdate)
                    {
                        video.last_score_calc = DateTime.Now;
                    }
                    context.SaveChanges();
                }
            }
        }

        public static decimal GetVideoScore(video video, OnlineCinemaEntities context)
        {
            // see http://www.kinopoisk.ru/top/#formula
            var score = from vote in video.reviews
                let averegeForVideo = video.reviews.Average(v => v.rating)
                let averageTotal = context.reviews.Average(v => v.rating)
                let votesCount = video.reviews.Count
                select
                    votesCount*averageTotal/(votesCount + MinimalVoteLimit) +
                    MinimalVoteLimit*averageTotal/(votesCount + MinimalVoteLimit);
            return Convert.ToDecimal(score.FirstOrDefault());
        }

        public void Stop(bool immediate)
        {
            lock (_lock)
            {
                _shuttingDown = true;
            }

            HostingEnvironment.UnregisterObject(this);
        }
    }
}