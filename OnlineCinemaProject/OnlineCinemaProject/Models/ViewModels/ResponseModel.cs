using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models
{
    public class Response
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public static Response CommentAdded = new Response
        {
            ResponseCode = 1006,
            ResponseMessage = "Коментарии успешно добавлены"
        };

        public static Response SubscriptionSacceeded = new Response
        {
            ResponseCode = 1004,
            ResponseMessage = "подписка на тариф выполнена"
        };

        public static Response LackOfMoney = new Response
        {
            ResponseCode = 1003,
            ResponseMessage = "Ндостаточно средств на балансе"
        };

        public static Response UserNotAuthorithed = new Response
        {
            ResponseCode = 1000,
            ResponseMessage = "Пользователь не автаризован"
        };

        public static Response MovieAccessDenied = new Response
        {
            ResponseCode = 1001,
            ResponseMessage = "Для просмотра оплатите стоимость фильма"
        };
        public static Response MovieAccessAllowed = new Response
        {
            ResponseCode = 1002,
            ResponseMessage = "Доступ к фильму разрешен"
        };
        public static Response LikeSucceeded = new Response
        {
            ResponseCode = 1005,
            ResponseMessage = "И я тебя также"
        };

        public static Response EmptyResponse = new Response();


    }
}