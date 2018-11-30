using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFareCalculator.BusinessLogic;
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
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 8, 30, 0),
            };

            double expected = 8.75;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFare_NoAddons_PeakTimeAndSaturday()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2018, 12, 01),
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 12, 01, 17, 30, 0),
            };
            FareCalculator calculator = new FareCalculator();

            double expected = 8.75;

            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CalculateFare_NoAddons_PeakTimeAndSunday()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2018, 12, 02),
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 12, 02, 17, 30, 0),
            };
            FareCalculator calculator = new FareCalculator();

            double expected = 8.75;

            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(actual, expected);
        }
        
        [TestMethod]
        public void CalculateFare_ShouldBePeakWeekday()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 16, 0, 0),
            };

            double expected = 9.75;

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
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 6, 0, 0),
            };

            double expected = 9.25;

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
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                // 8 PM
                StartTime = new System.DateTime(2010, 10, 08, 20, 0, 0),
            };

            double expected = 10.25;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFare_OvernightAddon_MaxFringePeak()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 20, 00, 01),
            };

            double expected = 9.25;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFare_NoAddons_MinFringePeak()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 15, 59, 59),
            };

            double expected = 8.75;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFare_NoAddons_MinFringeOvernight()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = 2,
                StartTime = new System.DateTime(2010, 10, 08, 6, 00, 01),
            };

            double expected = 8.75;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFare_NoAddons_PartialMilesBelowSixMph()
        {
            // Arrange
            TaxiRide ride = new TaxiRide
            {
                RideDate = new System.DateTime(2010, 10, 08),
                MinutesAboveSixMph = 5,
                MilesBelowSixMph = .4,
                StartTime = new System.DateTime(2010, 10, 08, 6, 00, 01),
            };

            double expected = 5.95;

            FareCalculator calculator = new FareCalculator();
            // Act
            double actual = calculator.CalculateFare(ride);
            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
