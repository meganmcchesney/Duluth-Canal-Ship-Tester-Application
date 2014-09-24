namespace ShipTester.Tests
{
    using Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ShipTestExtensionsTests
    {
        [TestMethod]//green
        public void SuccessfulIsInDuluthSuperiorHarbor()
        {
            var shipPositionsInHarbor = new[]
            {
                new Position("ShipD", 46.771041, -92.097696), 
                new Position("ShipE", 46.731052, -92.068857), 
                new Position("ShipG", 46.753887, -92.079929), 
                new Position("ShipH", 46.739889, -92.134861)
            };

            foreach (var position in shipPositionsInHarbor)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsTrue(
                    shipTest.IsInDuluthSuperiorHarbor()
                );
            }
        }

        [TestMethod]//green
        public void SuccessfulIsNotInDuluthSuperiorHarbor()
        {
            var shipPositionsOutOfHarbor = new[]
            {
                new Position("ShipA", 46.737640, -92.138895),
                new Position("ShipB", 46.775274, -91.946634),
                new Position("ShipC", 46.734346, -91.766733),
                new Position("ShipF", 46.771290, -92.080787),
                new Position("ShipI", 46.944402, -91.116686),
                new Position("ShipJ", 47.444500, -90.556929)
            };

            foreach (var position in shipPositionsOutOfHarbor)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsFalse(
                    shipTest.IsInDuluthSuperiorHarbor()
                );
            }
        }

        [TestMethod]//green
        public void SuccessfulIsInStLouisBay()
        {
            var shipPositionsInStLouisBay = new[]
            {
                new Position("ShipA", 46.754899, -92.121966),
                new Position("ShipB", 46.750444, -92.114499),
                new Position("ShipC", 46.750326, -92.135227),
                new Position("ShipD", 46.763178, -92.094319)
            };

            foreach (var position in shipPositionsInStLouisBay)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsTrue(
                    shipTest.IsInStLouisBay()
                );
            }

        }

        [TestMethod]//green
        public void SuccessfulIsNotInStLouisBay()
        {
            var shipPositionsNotInStLouisBay = new[]
            {
                new Position("ShipA", 46.757677, -92.000644)
            };

            foreach (var position in shipPositionsNotInStLouisBay)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsFalse(
                    shipTest.IsInStLouisBay()
                );
            }

        }

        [TestMethod]//green
        public void SuccessfulIsInDuluthSuperiorHarborForMoreThanHourTest()
        {
            var shipPositionsInHarbor = new[]
            {
                new Position("ShipD", 46.771041, -92.097696), 
                new Position("ShipE", 46.731052, -92.068857), 
                new Position("ShipG", 46.753887, -92.079929), 
                new Position("ShipH", 46.739889, -92.134861)
            };

            foreach (var position in shipPositionsInHarbor)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsTrue(
                    shipTest.IsInDuluthSuperiorHarborForMoreThanHour()
                );
            }

        }

        [TestMethod]
        public void SuccessfulIsNotInDuluthSuperiorHarborForMoreThanHourTest()
        {

        }

        [TestMethod]
        public void SuccessfulIsWithinFiftyMilesOfDuluthTest()
        {
            var shipPositionsInFiftyMiles = new[]
            {
                new Position("ShipA", 46.737640, -92.138895)
            };

            foreach (var position in shipPositionsInFiftyMiles)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsTrue(
                    shipTest.IsWithinFiftyMilesOfDuluth()
                );
            }
        }

        [TestMethod]//green
        public void SuccessfulIsNotWithinFiftyMilesOfDuluthTest()
        {
            var shipPositionsWayOut = new[]
            {
                new Position("ShipA", 48.306980, -87.162673),
                new Position("ShipB", 47.807653, -86.569412),
                new Position("ShipC", 47.109425, -85.031326),
                new Position("ShipD", 47.120640, -87.755935),
                new Position("ShipE", 47.984439, -88.294265)
            };

            foreach (var position in shipPositionsWayOut)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsFalse(
                    shipTest.IsWithinFiftyMilesOfDuluth()
                );
            }

        }

        [TestMethod]//green
        public void SuccessfulIsDestinationDuluthTest()
        {
            var shipTest = new ShipTest { Destination = Ports.Duluth };
            Assert.IsTrue(
                shipTest.IsDestinationDuluth()
            );
        }

        [TestMethod]//green
        public void SuccessfulIsDestinationNotDuluthTest()
        {
            var shipTest = new ShipTest { Destination = new Position("PortB", 46.706075, -92.016733) };
            Assert.IsFalse(
                shipTest.IsDestinationDuluth()
            );
        }

        [TestMethod]//green
        public void SuccessfulIsUnderwayTest()
        {
            var underway =
                new ShipTest() { NavigationalStatus = NavigationalStatus.Underway };

            Assert.IsTrue(
                underway.IsUnderway()
                );
        }

        [TestMethod]//green
        public void SuccessfulIsNotUnderwayTest()
        {
            var underway =
                new ShipTest() { NavigationalStatus = NavigationalStatus.Other };

            Assert.IsFalse(
                underway.IsUnderway()
                );
        }

        [TestMethod]
        public void SuccessfulIsMovingTowardDuluthTest()
        {

        }

        [TestMethod]
        public void SuccessfulIsNotMovingTowardDuluthTest()
        {

        }

        [TestMethod]
        public void SuccessfulIsHeadingTowardDuluthTest()
        {

        }

        [TestMethod]
        public void SuccessfulIsNotHeadingTowardDuluthTest()
        {

        }
    }
}

