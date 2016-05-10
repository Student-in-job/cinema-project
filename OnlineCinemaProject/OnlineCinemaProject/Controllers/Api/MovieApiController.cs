using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    public class MovieApiController : ApiController
    {
        IEnumerable<string> _headerValues;
        string _userId;
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();


        /*[HttpGet]
        [Route("api/movie/watch/{fileId}")]
        public JSendResponse WatchMovie(int fileId)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            movy movie = _db.movies.Find(movieId);
            if (movie == null)
            {
                return JSendResponse.errorResponse(Error.FileNotFoundError());
            }
            if (_userId==null )
            {
                if (movie.price==0)
                {
                    return JSendResponse.succsessResponse();                           
                }
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }
            
            aspnetuser user = _db.aspnetusers.Find(_userId);
            if (user == null)
            {
                return JSendResponse.errorResponse(Error.UserNotFound());
            }

            if (!user.CheckAccess(movie))
            {
                return JSendResponse.failResponse("Для доступа к видео оплатите стоимость просмотра!");
            }
            moviehistory moviehistory = new moviehistory
            {
                aspnetuser = user,
                movy = movie,
                watching_date = DateTime.Now
            };
            _db.moviehistories.Add(moviehistory);
            _db.SaveChanges();
            return JSendResponse.succsessResponse();
        }*/

        /*[HttpGet]
        [Route("api/movie/buy/{movieId}")]
        public JSendResponse BuyMovie(int movieId)
        {

            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }
            var user = _db.aspnetusers.Find(_userId);
            var movie = _db.movies.Find(movieId);

            if ( user == null)
            {
                return JSendResponse.errorResponse(Error.UserNotFound());
            }
            if (movie == null)
            {
                return JSendResponse.errorResponse(Error.FileNotFoundError());
            }


            if (!user.DrawMoney(movie.price))
            {
                return JSendResponse.failResponse("Ндостаточно средств на балансе");
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

            return JSendResponse.succsessResponse();

        }*/
    }
}
