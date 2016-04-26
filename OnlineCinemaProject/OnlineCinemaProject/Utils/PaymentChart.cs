using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Utils
{
    public static class DateUtils
    {
        public static string GetMonthName(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }
    }

    public class PaymentTotal
    {
        public string MonthName { get; set; }
        public decimal Total { get; set; }
    }
}