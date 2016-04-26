using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
// ReSharper disable All

namespace OnlineCinemaProject.Models
{

    public class Purchase
    {
        public class UserMovie
        {
            public int id { get; set; }
            public string videoImgUrl { get; set; }
            public int movieId { get; set; }
            public string videoName { get; set; }
            public System.DateTime purchaseDate { get; set; }
            public decimal price { get; set; }
        }

        public class UserSeason
        {
            public int id { get; set; }
            public string videoImgUrl { get; set; }
            public int seasonId { get; set; }
            public string videoName { get; set; }
            public System.DateTime purchaseDate { get; set; }
            public decimal price { get; set; }
        }
        public List<UserSeason> Userseasons { get; set; }
        public List<UserMovie> Usermovies{ get; set; }
    }
    public class History
    {
        public class MovieHistory
        {
            public int id { get; set; }
            public string videoImgUrl { get; set; }
            public int movieId { get; set; }
            public string videoName { get; set; }
            public System.DateTime watchingDate { get; set; }
        }

        public class EpisodeHistory
        {
            public int id { get; set; }
            public int episodeId { get; set; }
            public string videoName { get; set; }
            public string videoImgUrl { get; set; }
            public System.DateTime watchingDate { get; set; } 
        }

        public List<EpisodeHistory> Episodehistories { get; set; }
        public List<MovieHistory> Moviehistories{ get; set; }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Profile
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public DateTime? birthDate { get; set; }
        public string email { get; set; }
        public int? sex { get; set; }
        public decimal? balance { get; set; }

        public SubscriptionInfo subscription;
    }

    public partial class aspnetuser
    {
        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public subscription GeSubscription()
        {
            foreach (var subscription in subscriptions)
            {
                if (subscription.Active())
                {
                    return subscription;
                }
            }
            return null;
        }

        public bool CheckAccess(movy movie)
        {
            if (movie.price == 0)// если фильм бесплатный то даем добро для просмотра
            {
                return true;
            }
            if (HasMovie(movie))
            {
                return true;
            }
            return subscriptions.Any(subscription => subscription.Active() && subscription.tariff.Includes(movie));
        }

        public bool CheckAccess(episode episode)
        {
            if (episode.season.price == 0)// если фильм бесплатный то даем добро для просмотра
            {
                return true;
            }
            if (HasMovie(episode))
            {
                return true;
            }
            return subscriptions.Any(subscription => subscription.Active() && subscription.tariff.Includes(episode.season));
        }
        public bool HasMovie(movy movie)
        {
            if (usermovies.Count(i => i.movie_id == movie.id) != 0)//Если фильм уже куплен то даем добро для просмотра
            {
                return true;
            }
            return false;
        }

        public bool HasMovie(episode episode)
        {
            if (userseasons.Count(i => i.season_id == episode.season.id) != 0)//Если фильм уже куплен то даем добро для просмотра
            {
                return true;
            }
            return false;
        }

        public void TopUpBalance(decimal amount)
        {
            this.Balance = this.Balance + amount;
        }

        public bool DrawMoney(decimal amount)// Снять деньги со счета клиента
        {
            if (!CheckBalance(amount)) return false;
            Balance = Balance - amount;
            return true;
        }

        public bool CheckBalance(decimal amount) // проверить хватит ли денег 
        {
            if (Balance < amount)
            {
                return false;
            }
            return true;
        }
    }
}