using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public int? Sex { get; set; }
        public decimal? Balance { get; set; }
        public int? tariffId { get; set; }
        public string tariffName { get; set; }
    }

    /*public partial class aspnetuser
    {
        public string FullName()
        {
            return FirstName + " " + LastName;
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
    }*/
}