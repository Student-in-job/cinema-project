using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Newtonsoft.Json;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.Utils;

namespace OnlineCinemaProject.Controllers.Api
{
    
    public class VideoApiController : ApiController
    {
        private OnlineCinemaEntities _db = new OnlineCinemaEntities();
        //Get: api/video/get
        [Route("api/video")]
        public HttpResponseMessage GetVideo()
        {
            var videos = _db.videos.ToList();
            List<VideoInfo> Videos = new List<VideoInfo>();
            foreach (var item in videos)
            {
                Videos.Add(VideoUtils.GetVideoInfo(item));
            }
            return Request.CreateResponse(HttpStatusCode.OK, Videos);
        }

        //Get: api/video/get/5
        [Route("api/video/{id}")]
        public HttpResponseMessage GetVideoById(int id)
        {
            video video = _db.videos.Find(id);
            if (video == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, VideoUtils.GetVideoInfo(video));
        }
        [Route("api/video/new")]
        public HttpResponseMessage GetNewVideo()
        {
            var videos = _db.videos.OrderByDescending(i=>i.release_date).Take(10).ToList();/*Todo add creation date column to the video table*/
            List<VideoInfo> Videos = new List<VideoInfo>();
            foreach (var item in videos)
            {
                Videos.Add(VideoUtils.GetVideoInfo(item));
            }
            return Request.CreateResponse(HttpStatusCode.OK, Videos);
        }

        [Route("api/video/popular")]
        public HttpResponseMessage GetMostPopularVideo()
        {
            var movies = _db.movies.OrderByDescending(i => i.moviehistories.Count).Take(10).ToList();
            ICollection<video> videos = new List<video>();
            foreach (var movie in movies)
            {
                videos.Add(movie.video);
            }
            List<VideoInfo> Videos = new List<VideoInfo>();
            foreach (var item in videos)
            {
                Videos.Add(VideoUtils.GetVideoInfo(item));
            }
            return Request.CreateResponse(HttpStatusCode.OK, Videos);
        }

    }

}
