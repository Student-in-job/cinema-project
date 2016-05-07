using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Utils
{
    public static class Utils
    {
        public static string GetMonthName(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }

        public static double GetIncome(List<payment> payments )
        {
            return payments.Where(item => item.payment_type).Sum(item => (double) item.amount);
        }
        
        public static double GetAccount(List<aspnetuser> users )
        {
            return users.Where(item => item.Balance != null).Sum(item => (double) item.Balance);
        }

    }

    public class PaymentTotal
    {
        public string MonthName { get; set; }
        public decimal Total { get; set; }
    }
}