using System;

namespace TaxiFareCalculator.Models
{
    public class TaxiRide
    {
        public int MinutesAboveSixMph { get; set; }
        public double MilesBelowSixMph { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime RideDate { get; set; }
        public double StartTimeMinutes { get { return StartTime.Hour * 60 + StartTime.Minute + ((double)StartTime.Second / 60d); } }
        public double FarePrice { get; set; }
    }
}