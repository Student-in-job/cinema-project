using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
// ReSharper disable All

namespace OnlineCinemaProject.Models
{
    public class HistoryModel
    {
        public int id { get; set; }
        public string videoImgUrl { get; set; }
        public int fileId { get; set; }
        public string videoName { get; set; }
        public System.DateTime watchingDate { get; set; }
    }


    /*public class PurchaseModel
    {
        public int id { get; set; }
        public string videoImgUrl { get; set; }
        public int fileId { get; set; }
        public string videoName { get; set; }
        public System.DateTime purchaseDate { get; set; }
        public decimal price { get; set; }
    }*/

     public class Purchase
     {
         public Purchase()
         {
             Userseasons = new List<UserSeason>();
             Usermovies = new List<UserMovie>();
         }

         public class UserMovie
        {
            public int id { get; set; }
            public string videoImgUrl { get; set; }
            public int fileId { get; set; }
            public string videoName { get; set; }
            public System.DateTime purchaseDate { get; set; }
            public decimal price { get; set; }
        }

        public class UserSeason
        {
            public int id { get; set; }
            public string videoImgUrl { get; set; }
            public int seasonNunber { get; set; }
            public int seasonId { get; set; }
            public string videoName { get; set; }
            public System.DateTime purchaseDate { get; set; }
            public decimal price { get; set; }
        }
        public List<UserSeason> Userseasons { get; set; }
        public List<UserMovie> Usermovies{ get; set; }
    }
    /*public class History
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
    }*/

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
        public subscription GetSudscription()
        {
            var sub = this.subscriptions.Where(i => i.tariff_id == TariffId).OrderBy(i => i.start).ToList();
            if (sub.Count != 0)
            {
                return sub.FirstOrDefault();
            }
            return null;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }


        public bool CheckSubscription(file file)
        {
            var sub = GetSudscription();
            /*return subscriptions.Any(subscription => subscription.Active() && subscription.tariff.Includes(file));*/
            if (sub != null)
            {
                if (sub.Active() && tariff.Includes(file))
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool CheckSubscription(season season)
        {
            var sub = GetSudscription(); 
            /*return subscriptions.Any(subscription => subscription.Active() && subscription.tariff.Includes(file));*/
            if (sub != null)
            {
                if (sub.Active() && tariff.Includes(season))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckAccess(file file)
        {
            if (file.price == 0) // если фильм бесплатный то даем добро для просмотра
            {
                return true;
            }
            if (checkPurchases(file))
            {
                return true;
            }
            return CheckSubscription(file);
        }
        public bool CheckAccess(season season)
        {
                if (season.price == 0)// если фильм бесплатный то даем добро для просмотра
                {
                    return true;
                }
                if (checkPurchases(season))
                {
                    return true;
                }

                return CheckSubscription(season);
        }

        /*public bool CheckAccess(episode episode)
        {
            
            return subscriptions.Any(subscription => subscription.Active() && subscription.tariff.Includes(episode.season));
        }*/

        public bool checkPurchases(file file)
        {  
            if (purchases.Count(i => i.file_id == file.id) != 0)
            {
                return true;
            }
            return false;
        }
    
        public bool checkPurchases(season season)
        {
            if (userseasons.Count(i => i.season_id == season.id) != 0)
            {
                return true;
            }
            return false;
        }

        /*public bool HasMovie(movy movie)
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
        }*/

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