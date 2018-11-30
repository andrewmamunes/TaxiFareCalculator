using System;

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