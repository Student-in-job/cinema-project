using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.Utils;

namespace OnlineCinemaProject.Controllers.Api
{
    public class EpizodeController : ApiController
    {
        readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();
        IEnumerable<string> _headerValues;
        string _userId;

        [HttpGet]
        [Route("api/episode/watch/{episodeId}")]
        public HttpResponseMessage WatchEpisode(int episodeId)
        {
            var episode = _db.episodes.Find(episodeId);
            if (episode == null)
            {
                return Request.CreateResponse<Response>(HttpStatusCode.NotFound, Response.EmptyResponse);
            }
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            
            if (_userId == null)
            {
                if (episode.season.price == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Response.MovieAccessAllowed);
                }
                return Request.CreateResponse(HttpStatusCode.OK, Response.MovieAccessDenied);
            }
            var user = _db.aspnetusers.Find(_userId);
            if (user == null)
            {
                return Request.CreateResponse<Response>(HttpStatusCode.NotFound, Response.EmptyResponse);
            }

            if (!UserUtils.CheckAccess(user,episode))
            {
                return Request.CreateResponse(HttpStatusCode.OK, Response.MovieAccessDenied);
            }
            
            episodehistory episodehistory = new episodehistory
            {
                aspnetuser = user,
                episode = episode,
                watching_date = DateTime.Now
            };

            _db.episodehistories.Add(episodehistory);
            _db.SaveChanges();
            return Request.CreateResponse<Response>(HttpStatusCode.OK, Response.MovieAccessAllowed);
        }
    }
}
