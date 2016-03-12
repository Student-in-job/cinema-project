using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    public class UserController : ApiController
    {
        readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();
        [HttpGet]
        [Route("api/user/{userId}/{tariffId}")]
        public IHttpActionResult Subscribe(string userId, int tariffId)
        {
            var user = _db.aspnetusers.Find(userId);
            var tariff = _db.tariffs.Find(tariffId);
            if (tariff == null || user == null)
            {
                return NotFound();
            }
            if (DrawMoney(user,tariff.price))
            {
                return InternalServerError(new Exception("Ндостаточно средств на балансе"));
            }
            subscription subscription = new subscription
            {
                tariff = tariff,
                payment = tariff.price,
                start = DateTime.Now,
                end = DateTime.Now
            };
            subscription.aspnetusers.Add(user);

            _db.subscriptions.Add(subscription);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("api/user/{userId}/{amount}")]
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

        public IHttpActionResult Watch(int movieId, string userId)
        {
            var movie = _db.movies.Find(movieId);
            var user = _db.aspnetusers.Find(userId);
            if (movie == null || user == null)
            {
                return NotFound();
            }
            var userMovies = user.usermovies.Where(i => i.movie_id == movieId);
            if (true)
            {

            }
            if (movie.price.Equals(0))
            {
                return NotFound();
            }
            else
            {
                if(CheckBalance(user.Balance,movie.price))
                {

                }
            }
            return NotFound();
        }

        public bool DrawMoney(aspnetuser user, decimal amount)// Снять деньги со счета клиента
        {
            if (CheckBalance((decimal)user.Balance, amount))
            {
                user.Balance = user.Balance - amount;
                return true;
            }
            return false;
        }

        public void TopUp(aspnetuser user, decimal amount)
        {
            user.Balance += amount;
        }

        public bool CheckBalance(decimal balance, decimal amount ) // проверить хватит ли денег 
        {
            if (balance < amount)
            {
                return false;
            }
            return true;
        }
    }
}
