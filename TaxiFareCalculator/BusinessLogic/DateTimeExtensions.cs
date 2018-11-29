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
            return (rideDate.DayOfWeek == DayOfWeek.Saturday) || (rideDate.DayOfWeek == DayOfWeek.Sunday) ? false : true;
        }
    }
}