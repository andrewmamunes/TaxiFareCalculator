using TaxiFareCalculator.Models;

namespace TaxiFareCalculator.BusinessLogic.Abstractions
{
    interface IFareCalculator
    {
        double CalculateFare(TaxiRide ride);
    }
}
