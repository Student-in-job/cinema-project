using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    public class TariffController : ApiController
    {
        OnlineCinemaEntities db = new OnlineCinemaEntities();
        [HttpGet]
        [Route("api/tariff/{userId}/{tariffId}")]
        public IHttpActionResult Subscribe(string userId, int tariffId)
        {
            var user = db.aspnetusers.Find(userId);
            var tariff = db.tariffs.Find(tariffId);
            if (tariff == null || user == null)
            {
                return NotFound();
            }
            if (user.Balance < tariff.price)
            {
                return InternalServerError(new Exception("Ндостаточно средств на балансе"));
            }

            return Ok(tariff);
        }
    }
}
