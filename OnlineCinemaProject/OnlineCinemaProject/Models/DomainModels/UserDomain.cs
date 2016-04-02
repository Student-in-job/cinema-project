using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models.DomainModels
{
    public class UserDomain : aspnetuser
    {
        public bool CheckAccess(MovieDomain movie )
        {
            if (movie.price == 0)
            {
                return true;
            }
            if (usermovies.Where(i => i.movie_id == movie.id) != null)
            {
                return true;
            }
            //todo check tariff
            return false;
        }
    }
}