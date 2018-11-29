using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxiFareCalculator.BusinessLogic;
using TaxiFareCalculator.BusinessLogic.Abstractions;
using TaxiFareCalculator.Models;
namespace TaxiFareCalculatorTest
{
    [TestClass]
    public class FareCalculatorTest
    {
        [TestMethod]
        public void CalculateFare_BaseCase()
        {
            // Arrange
            TaxiRide ride = new TaxiRide{
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 17, 30,0),
            };
            FareCalculator calculator = new FareCalculator();

            double expected = 9.75;

            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CalculateFare_NoAddons()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 0,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 8, 30, 0),
            };

            double expected = 7.00;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFare_ShouldBePeakWeekday()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 0,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 16, 0, 0),
            };

            double expected = 8.00;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFare_ShouldBeMaxOvernight()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 0,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 6, 0, 0),
            };

            double expected = 7.50;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFare_ShouldBeMinOvernightAndMaxPeak()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                // Friday
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 0,
                MilesBelowSixMph = 2,
                // 8 PM
                StartTime = new System.DateTime(2010, 10, 08, 20, 0, 0),
            };

            double expected = 8.50;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
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
                MinutesAboveSixMph =-1,
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
