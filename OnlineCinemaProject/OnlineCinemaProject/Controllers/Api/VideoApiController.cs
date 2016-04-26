using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    
    public class VideoApiController : ApiController
    {
        IEnumerable<string> _headerValues;
        string _userId;
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        //Get: api/video
        [Route("api/video")]
        public HttpResponseMessage GetVideo()
        {
            var videos = _db.videos.ToList();
            List<VideoInfo> videoInfos = videos.Select(item => item.GetVideoInfo()).ToList();//todo is that is right?
            return Request.CreateResponse(HttpStatusCode.OK, videoInfos);
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

            return Request.CreateResponse(HttpStatusCode.OK, video.GetVideoInfo());
        }
        [Route("api/video/new")]
        public HttpResponseMessage GetNewVideo()
        {
            var videos = _db.videos.OrderByDescending(i=>i.release_date).Take(10).ToList();/*Todo add creation date column to the video table*/
            List<VideoInfo> videoInfos = videos.Select(item => item.GetVideoInfo()).ToList();// todo i dont like i, but i do it
            return Request.CreateResponse(HttpStatusCode.OK, videoInfos);
        }

        [Route("api/video/popular")]
        public HttpResponseMessage GetMostPopularVideo()
        {
            var movies = _db.movies.OrderByDescending(i => i.moviehistories.Count).Take(10).ToList();
            ICollection<video> videos = movies.Select(movie => movie.video).ToList();
            List<VideoInfo> videoInfos = videos.Select(item => item.GetVideoInfo()).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, videoInfos);
        }

        [Route("api/video/search/{key}")]
        public HttpResponseMessage Search(string key)
        {
            var videos = from v in _db.videos select v;
            ;
            if (!String.IsNullOrEmpty(key))
            {
                videos = videos.Where(s => s.name.ToUpper().Contains(key.ToUpper())
                                       || s.details.ToUpper().Contains(key.ToUpper()));
            }

            List<VideoInfo> videoInfos = videos.Select(item => item.GetVideoInfo()).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, videoInfos);
        }

        /*[Route("api/video/like/{id}/{value}")]
        public HttpResponseMessage Like(int id, bool value)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Response.UserNotAuthorithed);
            }
            var user = _db.aspnetusers.Find(_userId);
            var video = _db.videos.Find(id);
            if (user == null || video == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, Response.EmptyResponse);
            }
            
            
            like like = new like
            {
                aspnetuser = user,
                video = video,
                creation_date = DateTime.Now,
                value = value
            };

            _db.likes.Add(like);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, Response.LikeSucceeded);
        }*/

        /*[HttpPost]
        [Route("api/comment")]
        [ResponseType(typeof(comment))]
        public HttpResponseMessage Comment(comment comment)
        {
            comment.creation_date = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState); 
            }

            _db.comments.Add(comment);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, Response.CommentAdded); 
        }*/

        [HttpPost]
        [Route("api/overview")]
        [ResponseType(typeof(overview))]
        public HttpResponseMessage OverView(overview overview)
        {
            overview.creation_date = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _db.overviews.Add(overview);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, Response.CommentAdded);
        }
        
        [HttpGet]
        [Route("api/overview/{id}")]
        public HttpResponseMessage GetOverViews(int id)
        {
            var overviews = _db.overviews.Where(i => i.video_id == id).ToList();
            var commentInfos = overviews.Select(overview => new CommentInfo
            {
                id = overview.id, 
                author = overview.aspnetuser.FullName(), 
                authorId = overview.aspnetuser.Id, 
                comment = overview.comment, 
                creationDate = overview.creation_date
            }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, commentInfos);
        }





        


    }

}
