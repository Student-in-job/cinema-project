using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.Utils;

namespace OnlineCinemaProject.Controllers.Api
{
    public class UserApiController : ApiController
    {
        
        IEnumerable<string> _headerValues;
        string _userId;
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();
        
        [HttpGet]
        [Route("api/user/topup/{amount}")]
        public HttpResponseMessage TopUpBalance(decimal amount)
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
            if (user == null)
            {
                return Request.CreateResponse<Response>(HttpStatusCode.NotFound, Response.EmptyResponse);
            }

            UserUtils.TopUpBalance(amount,user);

            payment payment = new payment
            {
                aspnetuser = user,
                amount = amount,
                title = "Пополнение баланса",
                payment_type = true,
                payment_date = DateTime.Now,
            };
            _db.payments.Add(payment);
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
            return Request.CreateResponse<Response>(HttpStatusCode.OK, Response.EmptyResponse);;
        }

        [HttpGet]
        [Route("api/user/purchases")]
        public HttpResponseMessage GetUserPurchase()
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Response.UserNotAuthorithed);
            }
            var userseasons = _db.userseasons.Where(i => i.user_id == _userId).ToList();
            var usermovies = _db.usermovies.Where(i => i.user_id == _userId).ToList();
            List<Purchase.UserMovie> userMovies = new List<Purchase.UserMovie>();
            List<Purchase.UserSeason> userSeasons = new List<Purchase.UserSeason>();

            foreach (var item in userseasons)
            {
                userSeasons.Add(new Purchase.UserSeason
                {
                    id = item.id,
                    seasonId = item.season_id,
                    videoName = item.season.video.name,
                    purchaseDate = item.payment.payment_date,
                    videoImgUrl = item.season.video.img_url,
                    price = item.payment.amount
                    
                });
            }
            foreach (var item in usermovies)
            {
                userMovies.Add(new Purchase.UserMovie
                {
                    id = item.id,
                    movieId = item.movie_id,
                    videoName = item.movy.video.name,
                    purchaseDate = item.payment.payment_date,
                    videoImgUrl = item.movy.video.img_url,
                    price = item.payment.amount
                });
            }


            Purchase purchase = new Purchase
            {
                Usermovies = userMovies,
                Userseasons = userSeasons
            };
            return Request.CreateResponse(HttpStatusCode.OK, purchase); ;
        }

        [HttpGet]
        [Route("api/user/history")]
        public HttpResponseMessage GetUserHistory()
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Response.UserNotAuthorithed);
            }
            var moviehistories = _db.moviehistories.Where(i => i.user_id == _userId).ToList();
            var episodehistories = _db.episodehistories.Where(i => i.user_id == _userId).ToList();
            List<History.MovieHistory> movieHistories = new List<History.MovieHistory>();
            List<History.EpisodeHistory> episodeHistories = new List<History.EpisodeHistory>();

            foreach (var item in moviehistories)
            {
                movieHistories.Add(new History.MovieHistory
                {
                    id = item.id,
                    movieId = item.movie_id,
                    videoName = item.movy.video.name,
                    watchingDate = item.watching_date,
                    videoImgUrl = item.movy.video.img_url
                });
            }
            foreach (var item in episodehistories)
            {
                episodeHistories.Add(new History.EpisodeHistory
                {
                    id = item.id,
                    episodeId = item.episode_id,
                    videoName = item.episode.season.video.name,
                    watchingDate = item.watching_date,
                    videoImgUrl = item.episode.season.video.img_url
                });
            }
            History history = new History
            {
                Moviehistories = movieHistories,
                Episodehistories = episodeHistories
            };
            
            return Request.CreateResponse(HttpStatusCode.OK, history);
        }

        [HttpGet]
        [Route("api/user/profile")]
        public HttpResponseMessage GetUserProfile()
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
            
            Profile profile = new Profile
            {
                Balance =  user.Balance!=null? user.Balance:0,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate =  user.BirthDate,
                Sex =  user.Sex,
                Login = user.UserName
            };

            if (user.tariff != null)
            {
                profile.tariffId = user.TariffId;
                profile.tariffName = user.tariff.name;
            }
            return Request.CreateResponse(HttpStatusCode.OK, profile);
        }



    }
}
