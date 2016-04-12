using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models.Utils
{
    public static class UserUtils
    {
        public static bool CheckAccess(aspnetuser user, movy movie)
        {
            if (movie.price == 0)// если фильм бесплатный то даем добро для просмотра
            {
                return true;
            }
            if (HasMovie(movie, user))
            {
                return true;
            }
            foreach (var subscription in user.subscriptions)
            {
                if (SubscriptionUtils.Active(subscription) && TariffUtils.Includes(movie, subscription.tariff))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckAccess(aspnetuser user, episode episode)
        {
            if (episode.season.price == 0)// если фильм бесплатный то даем добро для просмотра
            {
                return true;
            }
            if (HasMovie(episode, user))
            {
                return true;
            }
            foreach (var subscription in user.subscriptions)
            {
                if (SubscriptionUtils.Active(subscription) && TariffUtils.Includes( episode.season, subscription.tariff))
                {
                    return true;
                }
            }
            return false;
        }

        public static string FullName(aspnetuser user)
        {
            return user.FirstName + " " + user.LastName;
        }

        public static bool HasMovie(movy movie, aspnetuser user)
        {
            if (user.usermovies.Count(i => i.movie_id == movie.id) != 0)//Если фильм уже куплен то даем добро для просмотра
            {
                return true;
            }
            return false;
        }

        public static bool HasMovie(episode episode, aspnetuser user)
        {
            if (user.userseasons.Count(i => i.season_id == episode.season.id) != 0)//Если фильм уже куплен то даем добро для просмотра
            {
                return true;
            }
            return false;
        }

        public static void TopUpBalance(decimal amount, aspnetuser user)
        {
            user.Balance = user.Balance + amount;
        }

        public static bool DrawMoney(decimal amount, aspnetuser user)// Снять деньги со счета клиента
        {
            if (!CheckBalance(amount, user)) return false;
            user.Balance = user.Balance - amount;
            return true;
        }

        public static bool CheckBalance(decimal amount, aspnetuser user) // проверить хватит ли денег 
        {
            if (user.Balance < amount)
            {
                return false;
            }
            return true;
        }
    }
}