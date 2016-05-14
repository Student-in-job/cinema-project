using System;
using System.Diagnostics.CodeAnalysis;
// ReSharper disable All

namespace OnlineCinemaProject.CustomResult
{
    public class Error
    {
        public int code;

        public string message;

        public static Error FileNotFoundError()
        {
            return new Error
            {
                code = 2000,
                message = "Файл не найден"
            };
        }
        public static Error UnAuthrizedUserError()
        {
            return new Error
            {
                code = 2001,
                message = "Пользователь не авторизован"
            };
        }

        public static Error UserNotFound()
        {
            return new Error
            {
                code = 2002,
                message = "Пользователь с таким Id не найден"
            };
        }

        public static Error VideoNotFound()
        {
            return new Error
            {
                code = 2003,
                message = "Видео с таким Id не найден"
            };
        }

        public static Error ModelStateInvalidError()
        {
            return new Error
            {
                code = 2004,
                message = "Чего то не хватает"
            };
        }

        public static Error CommentNotFoundError()
        {
            return new Error
            {
                code = 2005,
                message = "Коментарий не найден"
            };
        }

        public static Error AccessToFileDenied()
        {
            return new Error
            {
                code = 2006,
                message = "Отказано в доступе к файлу."
            };
        }

        public static Error SeasonNotFoundError()
        {
            return new Error
            {
                code = 2007,
                message = "Сезон с таким Id не найден."
            };
        }

        public static Error LackOfMoney()
        {
            return new Error
            {
                code = 2008,
                message = "Не хватает денег на счете"
            };
        }

        public static Error AdverticementDisabled()
        {
            return new Error
            {
                code = 2009,
                message = "Реклама отключена"
            };
        }

        public static Error UserAlreadySubscribed()
        {
            return new Error
            {
                code = 2010,
                message = "Подписаться на тариф можно только после окончания предыдущей"
            };
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class JSendResponse
    {
        
        public const string SUCCESS = "success";
        public const string FAIL = "fail";
        public const string ERROR = "error";

        public string status { get; set; }

        public Error error { get; set; }

        public Object data { get; set; }

        public static JSendResponse succsessResponse()
        {
            return new JSendResponse
            {
                status = SUCCESS
            };
        }

        public static JSendResponse succsessResponse(Object data)
        {
            return new JSendResponse
            {
                status = SUCCESS,
                data = data
            };
        }

        public static JSendResponse failResponse(Object data)
        {
            return new JSendResponse
            {
                status = FAIL
            };
        }

        public static JSendResponse errorResponse(Error error)
        {
            return new JSendResponse
            {
                status = ERROR,
                error = error
            };
        }

    }
}