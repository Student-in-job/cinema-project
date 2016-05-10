using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    public class TariffApiController : ApiController
    {
        readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();
        IEnumerable<string> _headerValues;
        string _userId;

        [HttpGet]
        [Route("api/tariff")]
        public JSendResponse GetTariffs()
        {
            var tariffs = _db.tariffs.Where(i => i.active == true).ToList();
            var tiriffInfos = tariffs.Select(tariff => tariff.GetTariffInfo()).ToList();
            return JSendResponse.succsessResponse(tiriffInfos);
        }

        [HttpGet]
        [Route("api/tariff/{id}")]
        public JSendResponse GetTariffsById(int id)
        {
            var tariff = _db.tariffs.Single(i => i.active == true && i.id == id);
            var tiriffInfo = tariff.GetTariffInfo();
             return JSendResponse.succsessResponse(tiriffInfo);
        }



        [HttpGet]
        [Route("api/tariff/subscribe/{tariffId}")]
        public JSendResponse Subscribe(int tariffId)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.succsessResponse(Error.UnAuthrizedUserError());
            }
            var tariff = _db.tariffs.Find(tariffId);
            var user = _db.aspnetusers.Find(_userId);
            if (tariff == null || user == null)
            {
                return JSendResponse.errorResponse(Error.UserNotFound());
            }
            
            if (!user.DrawMoney((decimal) tariff.price))
            {
                return JSendResponse.errorResponse(Error.LackOfMoney());
            }
            payment payment = new payment
            {
                aspnetuser = user,
                amount = (decimal) tariff.price,
                title = "Подписка на тариф " + tariff.name,
                payment_type = false,
                payment_date = DateTime.Now,
            };
            _db.payments.Add(payment);
            _db.SaveChanges();

            user.tariff = tariff;
            _db.Entry(user).State = EntityState.Modified;

            subscription subscription = new subscription
            {
                tariff = tariff,
                aspnetuser = user,
                payment = payment,
                start = DateTime.Now,
                end = DateTime.Now.AddMonths(1)
            };

            _db.subscriptions.Add(subscription);
            _db.SaveChanges();
            return JSendResponse.succsessResponse();
        }
    }
}
