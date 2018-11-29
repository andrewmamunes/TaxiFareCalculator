using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TaxiFareCalculator.BusinessLogic;
using TaxiFareCalculator.Models;

namespace TaxiFareCalculatorTest
{
    [TestClass]
    public class TaxiFareCalculatorExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateFare_NegativeMilesBelowSixMph_ShouldThrowArgumentException()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 0,
                MilesBelowSixMph = -1,
                StartTime = new System.DateTime(2010, 10, 08, 20, 0, 0),
            };

            FareCalculator calculator = new FareCalculator();
            // Act
            calculator.CalculateFare(ride);

            // Assert
            // Assert handled by attribute
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateFare_NegativeMinutesAboveSixMph_ShouldThrowArgumentException()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = -1,
                MilesBelowSixMph = 0,
                StartTime = new System.DateTime(2010, 10, 08, 20, 0, 0),
            };

            FareCalculator calculator = new FareCalculator();
            // Act
            calculator.CalculateFare(ride);

            // Assert
            // Assert handled by attribute
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateFare_NullRide_ShouldThrowNullArgumentException()
        {
            // Arrange
            TaxiRide ride = null;

            FareCalculator calculator = new FareCalculator();
            // Act
            calculator.CalculateFare(ride);

            // Assert
            // Assert handled by attribute
        }
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void CalculateFare_VeryLargeInput_ShouldThrowOverflowException()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 1.79769313486231E+308,
                MilesBelowSixMph = 1.79769313486231E+308,
                StartTime = new System.DateTime(2010, 10, 08, 20, 0, 0),
            };

            FareCalculator calculator = new FareCalculator();
            // Act
            calculator.CalculateFare(ride);

            // Assert
            // Assert handled by attribute
        }
    }
}
