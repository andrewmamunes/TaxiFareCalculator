using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiFareCalculator.Constants
{
    public static class FareConstants
    {
        public const double PEAK_SURCHARGE = 1.00;
        public const double NY_TAX_SURCHARGE = 0.50;
        public const double BASE_FARE = 3.00;
        public const double NIGHT_SURCHARGE = 0.50;
        public const double SLOW_FARE_RATE = 0.25;
        public const double FAST_FARE_RATE = 0.50;
        public const double UNIT_RATE = 0.35;
    }
}