using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models
{
    public partial class aspnetuser
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
            movy userMovie = usermovies.Single(i => i.movie_id == movie.id).movy;
            if (userMovie!=null)//Если фильм уже куплен то даем добро для просмотра
            {
                return true;
            }
            foreach (var subscription in subscriptions)
            {
                
                if (subscription.Active() && subscription.tariff.Includes(movie))//Ecли есть активнеая подписка и тариф подписки покрывает данный фильм то даем добро для просмотра
                {
                    return true;
                }
            }
            return false;
        }

        public void TopUpBalance(decimal amount)
        {
            this.Balance = this.Balance + amount;
        }
    }
}