using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiFareCalculator.BusinessLogic
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekday(this DateTime rideDate)
        {
            bool result = true;
            if ((rideDate.Day == (int)DayOfWeek.Saturday) || (rideDate.Day == (int)DayOfWeek.Sunday))
            {
                result = false;
            }
            return result;
        }
    }
}