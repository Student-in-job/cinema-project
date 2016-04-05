using System;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();
        [HttpGet]
        [Route("api/user/{userId}/{tariffId}")]
        public IHttpActionResult Subscribe(string userId, int tariffId)
        {
            var tariff = _db.tariffs.Find(tariffId);
            
            var user = _db.aspnetusers.Find(userId);
            if (tariff == null || user == null)
            {
                return new HttpActionResult(HttpStatusCode.NotFound, "Пользователя с данным Id не существует");
            }
            if (!DrawMoney(user,tariff.price))
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Ндостаточно средств на балансе");
            }
            payment payment = new payment
            {
                aspnetuser = user,
                amount = tariff.price,
                title = "Подписка на тариф "+ tariff.name,
                payment_type = false,
                payment_date = DateTime.Now,
            };
            _db.payments.Add(payment);
            _db.SaveChanges();

            subscription subscription = new subscription
            {
                tariff = tariff,
                payment = payment,
                start = DateTime.Now,
                end = DateTime.Now.AddMonths(1)
            };
            /*subscription.aspnetusers.Add(user); todo*/

            _db.subscriptions.Add(subscription);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("api/user/topup/{userId}/{amount}")]
        public IHttpActionResult TopUpBalance(string userId, decimal amount)
        {
            var user = _db.aspnetusers.Find(userId);
            if (user == null)
            {
                return NotFound();
            }
            TopUp(user,amount);
            return Ok();
        }

        [HttpGet]
        [Route("api/movie/watch/{movieId}/{userId}")]
        public IHttpActionResult WatchMovie(int movieId, string userId)
        {
            var movie = _db.movies.Find(movieId);
            var user = _db.aspnetusers.Find(userId);
            if (movie == null || user == null)
            {
                return NotFound();
            }
            
            if (!UserHasThisMovie(user,movie) || !movie.price.Equals(0) || !UserHasTariff(user))// если пользователь не купил ранее этот фильм или фильм не бесплатный
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Фильм платный заплотите сначала");
            }
            moviehistory moviehistory = new moviehistory
            {
                aspnetuser = user,
                movy = movie,
                watching_date = DateTime.Now
            };

            _db.moviehistories.Add(moviehistory);
            _db.SaveChanges();

            return Ok();
        }

        private bool UserHasTariff(aspnetuser user)
        {
           /* if (user.subscription.enabled)
            {
                return true;                
            }todo */ 
            return false;
        }

        [HttpGet]
        [Route("api/episode/watch/{movieId}/{userId}")]
        public IHttpActionResult WatchEpisode(int episodeId, string userId)
        {
            var episode = _db.episodes.Find(episodeId);
            var user = _db.aspnetusers.Find(userId);
            if (episode == null || user == null)
            {
                return NotFound();
            }
            
            if (!UserHasThisSeason(user,episode.season) || !episode.season.price.Equals(0) || !UserHasTariff(user))// если пользователь не купил ранее этот фильм или фильм не бесплатный
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Фильм платный заплотите сначала");
            }
            episodehistory episodehistory = new episodehistory
            {
                aspnetuser = user,
                episode = episode,
                watching_date = DateTime.Now
            };

            _db.episodehistories.Add(episodehistory);
            _db.SaveChanges();

            return Ok();
        }
        [HttpGet]
        [Route("api/movie/watch/{movieId}")]
        public IHttpActionResult WatchMovie(int movieId)
        {
            var movie = _db.movies.Find(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            if (!movie.price.Equals(0))
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Фильм платный зарегестрируйся для начала");
            }
            return Ok();
        }
        [HttpGet]
        [Route("api/episode/watch/{movieId}")]
        public IHttpActionResult WatchEpisode(int episodeId)
        {
            var episode = _db.episodes.Find(episodeId);
            if (episode == null )
            {
                return NotFound();
            }
            if (!episode.season.price.Equals(0))
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Фильм платный зарегестрируйся для начала");
            }
            return Ok();
        }

        public bool UserHasThisMovie(aspnetuser user, movy movie)
        {
            usermovy usermovy = new usermovy
            {
                aspnetuser = user,
                movy = movie,
            };
            if (user.usermovies.Contains(usermovy))
            {
                return true;
            }
            return false;
        }

        public bool DrawMoney(aspnetuser user, decimal amount)// Снять деньги со счета клиента
        {
            if (!CheckBalance(user.Balance, amount)) return false;
            user.Balance = user.Balance - amount;
            return true;
        }

        public void TopUp(aspnetuser user, decimal amount)
        {
            user.Balance += amount;
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
        }

        public bool CheckBalance(decimal? balance, decimal amount ) // проверить хватит ли денег 
        {
            if (balance < amount)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        [Route("api/movie/buy/{movieId}/{userId}")]
        public IHttpActionResult BuyMovie(int movieId, string userId)
        {
            var movie = _db.movies.Find(movieId);
            var user = _db.aspnetusers.Find(userId);
            if (movie == null || user == null)
            {
                return NotFound();
            }
            if (UserHasThisMovie(user, movie))
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Пользователь уже купил данный ф");
            }
            if(!DrawMoney(user,movie.price))
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Ндостаточно средств на балансе");
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

            return Ok();

        }
        [HttpGet]
        [Route("api/movie/buySeason/{seasonId}/{userId}")]
        public IHttpActionResult BuySeason(int seasonId, string userId)
        {
            var season = _db.seasons.Find(seasonId);
            var user = _db.aspnetusers.Find(userId);
            if (season == null || user == null)
            {
                return NotFound();
            }
            if (UserHasThisSeason(user, season))
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Пользователь уже купил данный сезон");
            }
            if (!DrawMoney(user, season.price))
            {
                return new HttpActionResult(HttpStatusCode.NotAcceptable, "Ндостаточно средств на балансе");
            }

            payment payment = new payment
            {
                aspnetuser = user,
                amount = season.price,
                title = "Покупка сезона" + season.name+", сериала" + season.video.name,
                payment_type = false,
                payment_date = DateTime.Now,
            };
            _db.payments.Add(payment);
            _db.SaveChanges();

            userseason userSeason = new userseason
            {
                aspnetuser = user,
                season = season,
                payment = payment,
            };

            _db.userseasons.Add(userSeason);
            _db.SaveChanges();

            return Ok();
        }



        private bool UserHasThisSeason(aspnetuser user, season season)
        {
            userseason userseason = new userseason()
            {
                aspnetuser = user,
                season = season
            };
            if (user.userseasons.Contains(userseason))
            {
                return true;
            }
            return false;
        }
    }
}
