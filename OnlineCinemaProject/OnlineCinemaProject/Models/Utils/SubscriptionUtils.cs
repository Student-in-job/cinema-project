using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models.Utils
{
    public static class SubscriptionUtils
    {
        public static bool Active(subscription subscription)
        {
            if (subscription.end > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}