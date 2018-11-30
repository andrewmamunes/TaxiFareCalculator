using TaxiFareCalculator.Models;
using TaxiFareCalculator.BusinessLogic.Abstractions;
using TaxiFareCalculator.Constants;
using System;

namespace TaxiFareCalculator.BusinessLogic
{
    public class FareCalculator : IFareCalculator
    {
        public double CalculateFare(TaxiRide ride)
        {
            try
            {
                #region Guards
                if (ride == null) {
                    throw new ArgumentNullException("You must submit a ride in order for it to be calculated");
                }
                if (ride.MinutesAboveSixMph < 0)
                {
                    throw new ArgumentException("Minutes above six mph must be non-negative");
                }
                if (ride.MilesBelowSixMph < 0)
                {
                    throw new ArgumentException("Miles above six mph must be non-negative");
                }
                #endregion
                double result = FareConstants.BASE_FARE + FareConstants.NY_TAX_SURCHARGE;
                if (IsPeakWeekday(ride))
                {
                    result += FareConstants.PEAK_SURCHARGE;
                }
                if (IsNight(ride))
                {
                    result += FareConstants.NIGHT_SURCHARGE;
                }

                result += ride.MilesBelowSixMph * 5d * FareConstants.UNIT_RATE;
                result += ride.MinutesAboveSixMph * FareConstants.UNIT_RATE;

                #region Overflow check
                // large inputs may result in overflow... unrealistic, but possible
                if (result == Double.PositiveInfinity) {
                    throw new OverflowException();
                }
                #endregion
                return result;
            }
            #region Exception Handling
            catch (OverflowException)
            {
                throw new OverflowException("The numbers you input were too large to be calculated properly");
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception)
            {
                throw new Exception("An unknown exception occurred when calculating your fare");
            }
            #endregion
        }

        private bool IsPeakWeekday(TaxiRide ride) {
            bool result;
            result = ((ride.StartTimeMinutes >= 960d) && (ride.StartTimeMinutes <= 1200d) && (ride.RideDate.IsWeekday()));
            return result;
        }
        private bool IsNight(TaxiRide ride) {
            return ((ride.StartTimeMinutes >= 1200d) || (ride.StartTimeMinutes <= 360d)) ? true : false;
        }
        private bool IsWeekday(TaxiRide ride) {
            return ((ride.StartTime.Day == (int)DayOfWeek.Saturday) || (ride.StartTime.Day == (int)DayOfWeek.Sunday));
            
        }
    }
}