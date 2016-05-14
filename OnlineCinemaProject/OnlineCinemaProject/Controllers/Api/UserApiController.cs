using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;
// ReSharper disable All
namespace OnlineCinemaProject.Controllers.Api
{
    public class UserApiController : ApiController
    {

        IEnumerable<string> _headerValues;
        string _userId;
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        [HttpGet]
        [Route("api/user/topup/{amount}")]
        public JSendResponse TopUpBalance(decimal amount)
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
            if (user == null)
            {
                return JSendResponse.errorResponse(Error.UserNotFound());
            }

            user.TopUpBalance(amount);

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
            return JSendResponse.succsessResponse();
        }

        [HttpGet]
        [Route("api/user/purchases")]
        public JSendResponse GetUserPurchases()
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }


            
            var userMovies = _db.purchases.Where(i => i.user_id == _userId).ToList();//todo zapros neverniy
            var userSeasons = _db.userseasons.Where(i => i.user_id == _userId).ToList();//todo zapros neverniy
            
            Purchase purchaseModels = new Purchase();

            foreach (var userMovie in userMovies)
            {
                purchaseModels.Usermovies.Add(new Purchase.UserMovie
                {
                    id = userMovie.id,
                    videoImgUrl = userMovie.file.video.img_url,
                    videoName = userMovie.file.video.name,
                    price = (decimal) userMovie.file.price,
                    fileId = (int) userMovie.file_id,
                    purchaseDate = (DateTime) userMovie.purchase_date
                });
            }

            foreach (var item in userSeasons)
            {
                purchaseModels.Userseasons.Add(new Purchase.UserSeason
                {
                    id = item.id,
                    seasonNunber = (int) item.season.season_number,
                    seasonId = (int) item.season.id,
                    videoName = item.season.video.name,
                    purchaseDate = item.payment.payment_date,
                    videoImgUrl = item.season.video.img_url,
                    price = item.payment.amount
                });
            }

            return JSendResponse.succsessResponse(purchaseModels);
        }

        [Route("api/user/subscription")]
        public JSendResponse GetUserSubscription()
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }

            var subs = _db.subscriptions.Where(i => i.user_id == _userId).OrderBy(i=>i.start).ToList();
            foreach (var item in subs)
            {
                if (!item.Active())
                {
                    subs.Remove(item);
                    if (subs.Count == 0)
                    {
                        break;
                    }
                }
            }

            SubscriptionInfo info = new SubscriptionInfo();
            

            return JSendResponse.succsessResponse(subs.FirstOrDefault().GetSubscriptionInfo());
            

        }


        [HttpGet]
        [Route("api/user/history")]
        public JSendResponse GetUserHistory()
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }
            var history = _db.histories.Where(i => i.user_id == _userId).ToList();
            List<HistoryModel> historyModels = new List<HistoryModel>();
            

            foreach (var item in history)
            {
                historyModels.Add(new HistoryModel
                {
                    id = item.id,
                    fileId = (int) item.file_id,
                    videoName = item.file.video.name,
                    watchingDate = (DateTime) item.watching_time,
                    videoImgUrl = item.file.video.img_url
                });
            }

            return JSendResponse.succsessResponse(historyModels);
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
                balance = user.Balance != null ? user.Balance : 0,
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                birthDate = user.BirthDate,
                sex = user.Sex,
                login = user.UserName
            };

            if (user.GetSudscription() != null)
            {
                profile.subscription = user.GetSudscription().GetSubscriptionInfo(); ;
            }
            return Request.CreateResponse(HttpStatusCode.OK, profile);
        }

        [HttpPost]
        [Route("api/user/password")]
        [ResponseType(typeof (ChangePassword))]
        public JSendResponse ChangePassword(ChangePassword changePassword)
        {
            if (!ModelState.IsValid)
            {
                JSendResponse.errorResponse(Error.ModelStateInvalidError());
            }

            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }
            var user = _db.aspnetusers.Find(_userId);
            if (user == null)
            {
                JSendResponse.errorResponse(Error.UserNotFound());
            }

            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            userManager.RemovePassword(_userId);
            userManager.AddPassword(_userId, changePassword.newPassword);

            return JSendResponse.succsessResponse();
        }

    }
}

/*
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using OnlineCinemaProject.Models;
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
                return Request.CreateResponse(HttpStatusCode.NotFound, Response.EmptyResponse);
            }

            user.TopUpBalance(amount);

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
            return Request.CreateResponse(HttpStatusCode.OK, Response.EmptyResponse);
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
//                return Request.CreateResponse(HttpStatusCode.OK, Response.UserNotAuthorithed);
                _userId = "ac1da694-6aee-4080-8c69-cac3342baada";
            }
            var test = _db.usermovies.SqlQuery("SELECT * FROM usermovies WHERE user_id = @id", new MySqlParameter("id", _userId)).ToList();
            //var usermovies = _db.usermovies.Where(i => i.user_id == _userId).ToList();//todo zapros neverniy
            //var rrr = _db.usermovies.Where(i => i.user_id == _userId);
            List<Purchase.UserMovie> userMovies = new List<Purchase.UserMovie>();

            foreach (var item in test)
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
                Usermovies = userMovies
            };
            return Request.CreateResponse(HttpStatusCode.OK, purchase); 
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
*/
