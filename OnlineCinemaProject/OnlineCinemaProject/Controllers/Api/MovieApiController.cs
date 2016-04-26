using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    public class MovieApiController : ApiController
    {
        IEnumerable<string> _headerValues;
        string _userId;
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();


        [HttpGet]
        [Route("api/movie/watch/{movieId}")]
        public HttpResponseMessage WatchMovie(int movieId)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            movy movie = _db.movies.Find(movieId);
            if (movie == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, Response.EmptyResponse);
            }
            if (_userId==null )
            {
                if (movie.price==0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Response.MovieAccessAllowed);                           
                }
                return Request.CreateResponse(HttpStatusCode.OK, Response.MovieAccessDenied);
            }
            
            aspnetuser user = _db.aspnetusers.Find(_userId);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, Response.EmptyResponse);
            }

            if (!user.CheckAccess(movie))
            {
                return Request.CreateResponse(HttpStatusCode.OK, Response.MovieAccessDenied);
            }
            moviehistory moviehistory = new moviehistory
            {
                aspnetuser = user,
                movy = movie,
                watching_date = DateTime.Now
            };
            _db.moviehistories.Add(moviehistory);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, Response.MovieAccessAllowed);
        }

        [HttpGet]
        [Route("api/movie/buy/{movieId}")]
        public HttpResponseMessage BuyMovie(int movieId)
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
            var movie = _db.movies.Find(movieId);

            if (movie == null || user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, Response.EmptyResponse);
            }

            if (!user.DrawMoney(movie.price))
            {
                return Request.CreateResponse(HttpStatusCode.OK, Response.LackOfMoney);
            }

            payment payment = new payment
            {
                aspnetuser = user,
                amount = movie.price,
                title = "Покупка фильма " + movie.video.name,
                payment_type = false,
                payment_date = DateTime.Now,
            };
            _db.payments.Add(payment);
            _db.SaveChanges();

            usermovy userMovie = new usermovy
            {
                aspnetuser = user,
                movy = movie,
                payment = payment,
            };

            _db.usermovies.Add(userMovie);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, Response.SubscriptionSacceeded);

        }
    }
}
