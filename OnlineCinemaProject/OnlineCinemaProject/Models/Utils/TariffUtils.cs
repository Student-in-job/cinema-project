using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models.Utils
{
    public static class TariffUtils
    {
        public static bool Includes(movy movie, tariff tariff)
        {
            if (!tariff.new_films_enabled) //если тариф не вкл. просмотр фильмов которые вышли на прокат недавно
            {
                //todo check if film is a prmier
                return true;
            }
            return true;
        }

        public static bool Includes(season season, tariff tariff)
        {
            if (!tariff.new_films_enabled) //если тариф не вкл. просмотр фильмов которые вышли на прокат недавно
            {
                //todo check if season is a prmier
                return true;
            }
            return true;
        }
    }
}