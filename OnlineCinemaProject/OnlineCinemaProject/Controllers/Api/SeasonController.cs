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
    public class SeasonController : ApiController
    {

        IEnumerable<string> _headerValues;
        string _userId;
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        [HttpGet]
        [Route("api/movie/buySeason/{seasonId}")]
        public HttpResponseMessage BuySeason(int seasonId)
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
            var season = _db.seasons.Find(seasonId);

            if (season == null || user == null)
            {
                return Request.CreateResponse<Response>(HttpStatusCode.NotFound, Response.EmptyResponse);
            }

            if (!UserUtils.DrawMoney(season.price, user))
            {
                return Request.CreateResponse<Response>(HttpStatusCode.OK, Response.LackOfMoney);
            }

            payment payment = new payment
            {
                aspnetuser = user,
                amount = season.price,
                title = "Покупка сезона" + season.name + ", сериала" + season.video.name,
                payment_type = false,
                payment_date = DateTime.Now,
            };
            _db.payments.Add(payment);
            _db.SaveChanges();

            userseason userseason = new userseason
            {
                aspnetuser = user,
                season = season,
                payment = payment,
            };

            _db.userseasons.Add(userseason);
            _db.SaveChanges();

            return Request.CreateResponse<Response>(HttpStatusCode.OK, Response.SubscriptionSacceeded);
        }
    }
}
