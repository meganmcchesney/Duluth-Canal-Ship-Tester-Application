namespace ShipTester.Tests.Helper
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShipTester.Helper;
    using ShipTester.Model;

    /// <summary>
    /// Class that runs tests on the GeoHelper class
    /// </summary>
    public class GeoHelperTests
    {
        /// <summary>
        /// A ship set "fifty" miles from the harbor, it's actually 38 miles.
        /// </summary>
        private static readonly Position TestShipPosition = ShipPositions.FiftyMilesFromDuluthCanal;

        /// <summary>
        /// A destination set to Duluth
        /// </summary>
        private static readonly Position TestDestination = Ports.Duluth;

        /// <summary>
        /// Set up all conditions for testing 
        /// call the method or trigger being tested
        /// Verify the results are correct
        /// Test each distance formula and their conversions
        /// </summary>
        [TestClass]
        public class DistanceFormulasTest
        {
            /// <summary>
            /// use http://boulter.com/gps/distance/ for expected distance calculations
            /// </summary>
            private const double ExpectedDistanceInMiles = 37.89;

            /// <summary>
            /// Expected distance in kilometers
            /// </summary>
            private const double ExpectedDistanceInKm = 60.98;

            /// <summary>
            /// Expected distance in Nautical miles
            /// </summary>
            private const double ExpectedDistanceInNmi = 32.93;

            /// <summary>
            /// The percentage of the expected value that should constitute the delta.
            /// </summary>
            private const double DeltaPercentage = 0.05;

            /// <summary>
            /// The successful Miles distance calculation test
            /// </summary>
            [TestMethod]
            public void SuccessfulDistanceCalculationInMiles()
            {
                Assert.AreEqual(
                    GeoHelper.DistanceBetweenCoord(TestDestination, TestShipPosition),
                    ExpectedDistanceInMiles,
                    ExpectedDistanceInMiles * DeltaPercentage
                );
            }

            /// <summary>
            /// The successful Kilometers distance calculation test
            /// </summary>
            [TestMethod]
            public void SuccessfulDistanceCalculationInKilometers()
            {
                Assert.AreEqual(
                    GeoHelper.DistanceBetweenCoord(TestDestination, TestShipPosition, GeoHelper.Units.KiloMeter),
                    ExpectedDistanceInKm,
                    ExpectedDistanceInKm * DeltaPercentage
                );
            }

            /// <summary>
            /// The successful Nautical Miles distance calculation test
            /// </summary>
            [TestMethod]
            public void SuccessfulDistanceCalculationInNauticalMiles()
            {
                Assert.AreEqual(
                    GeoHelper.DistanceBetweenCoord(TestDestination, TestShipPosition, GeoHelper.Units.NauticalMiles),
                    ExpectedDistanceInNmi,
                    ExpectedDistanceInNmi * DeltaPercentage
                );
            }            
        }

        /// <summary>
        /// Tests the GetBearing method and any related methods in GeoHelper
        /// </summary>
        [TestClass]
        public class BearingFormulaTest
        {
            /// <summary>
            /// Expected bearing according to http://www.movable-type.co.uk/scripts/latlong.html
            /// </summary>
            private const double ExpectedBearing = 250;

            /// <summary>
            /// The percentage of the expected value that should constitute the delta.
            /// </summary>
            private const double DeltaPercentage = 0.01;

            /// <summary>
            /// A successful bearing calculation assertion
            /// </summary>
            [TestMethod]
            public void SuccessfulBearingCalculation()
            {
                Assert.AreEqual(
                    GeoHelper.GetBearing(TestShipPosition, TestDestination),
                    ExpectedBearing,
                    ExpectedBearing * DeltaPercentage
                );
            }
        }
    }
}
