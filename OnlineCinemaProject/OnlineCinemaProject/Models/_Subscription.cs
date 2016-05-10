using System;
// ReSharper disable All

namespace OnlineCinemaProject.Models
{
    public class SubscriptionInfo
    {
        public int id;
        public int? tariffId;
        public string tariffName;
        public DateTime? start;
        public DateTime? end;
    }

    public partial class subscription
    {
        public bool Active()
        {
            if (end > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public SubscriptionInfo GetSubscriptionInfo()
        {
            return new SubscriptionInfo
            {
                id = id,
                end = end,
                start = start,
                tariffId = tariff_id,
                tariffName = tariff.name

            };
        }
    }
}