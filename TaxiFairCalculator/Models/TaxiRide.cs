using System;

namespace TaxiFareCalculator.Models
{
    public class TaxiRide
    {
        public double MinutesAboveSixMph { get; set; }
        public double MilesBelowSixMph { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime RideDate { get; set; }
        public int StartTimeMinutes { get { return StartTime.Hour * 60 + StartTime.Minute; } }
        public double FarePrice { get; set; }
    }
}