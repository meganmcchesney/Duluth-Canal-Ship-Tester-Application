namespace ShipTester.Tests.ShipTesting
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;
    using ShipTester.ShipTesting;

    /// <summary>
    /// The shipTest Extension tests.
    /// </summary>
    [TestClass]
    public class ShipTestExtensionsTests
    {
        /// <summary>
        /// Ship is in the Duluth Superior Harbor test.
        /// </summary>
        [TestMethod]
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

        /// <summary>
        /// Ship is not in the Duluth Superior Harbor test.
        /// </summary>
        [TestMethod]
        public void SuccessfulIsNotInDuluthSuperiorHarbor()
        {
            var shipPositionsOutOfHarbor = new[]
            {
                new Position("ShipA", 46.944402, -91.116686),
                new Position("ShipB", 47.444500, -90.556929)
            };

            foreach (var position in shipPositionsOutOfHarbor)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsFalse(
                    shipTest.IsInDuluthSuperiorHarbor()
                );
            }
        }

        /// <summary>
        ///     Ship is in the St. Louis Bay test.
        /// </summary>
        [TestMethod]
        public void SuccessfulIsInStLouisBay()
        {
            var shipPositionsInStLouisBay = new[]
            {
                new Position("ShipA", 46.754899, -92.121966),
                new Position("ShipB", 46.749253, -92.105229)
            };

            foreach (var position in shipPositionsInStLouisBay)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsTrue(
                    shipTest.IsInStLouisBay()
                );
            }
        }

        /// <summary>
        /// Ship is not in the St. Louis Bay test.
        /// </summary>
        [TestMethod]
        public void SuccessfulIsNotInStLouisBay()
        {
            var shipPositionsOutOfHarbor = new[]
            {
                new Position("ShipA", 46.775274, -91.946634),
                new Position("ShipB", 46.734346, -91.766733),
                new Position("ShipC", 46.771290, -92.080787),
                new Position("ShipD", 46.944402, -91.116686),
                new Position("ShipE", 47.444500, -90.556929),
                new Position("ShipF", 46.692577, -92.004368)
            };

            foreach (var position in shipPositionsOutOfHarbor)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsFalse(
                    shipTest.IsInStLouisBay()
                );
            }
        }

        /// <summary>
        /// Ship is within fifty miles of Duluth test.
        /// </summary>
        [TestMethod]
        public void SuccessfulIsWithinFiftyMilesOfDuluthTest()
        {
            var shipPositionsInFiftyMiles = new[]
            {
                new Position("ShipA", 46.737640, -92.138895),
                new Position("ShipB", 46.775274, -91.946634),
                new Position("ShipC", 46.734346, -91.766733),
                new Position("ShipD", 46.771041, -92.097696),
                new Position("ShipE", 46.731052, -92.068857),
                new Position("ShipF", 46.771290, -92.080787),
                new Position("ShipG", 46.753887, -92.079929),
                new Position("ShipH", 46.739889, -92.134861),
                new Position("ShipI", 46.944402, -91.116686)
            };

            foreach (var position in shipPositionsInFiftyMiles)
            {
                var shipTest = new ShipTest { Position = position };

                Assert.IsTrue(
                    shipTest.IsWithinFiftyMilesOfDuluth()
                );
            }
        }

        /// <summary>
        /// Ship is not within fifty miles of Duluth test.
        /// </summary>
        [TestMethod]
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

        /// <summary>
        /// Ship reports Duluth as its destination.
        /// </summary>
        [TestMethod]
        public void SuccessfulIsDestinationDuluthTest()
        {
            var shipTest = new ShipTest { Destination = Ports.Duluth };

            Assert.IsTrue(
                shipTest.IsDestinationDuluth()
            );
        }

        /// <summary>
        /// Ship reports something other than Duluth as its destination.
        /// </summary>
        [TestMethod]
        public void SuccessfulIsDestinationNotDuluthTest()
        {
            var shipTest = new ShipTest { Destination = new Position("PortB", 46.706075, -92.016733) };

            Assert.IsFalse(
                shipTest.IsDestinationDuluth()
            );
        }

        /// <summary>
        /// Ship reports navigational status as underway.
        /// </summary>
        [TestMethod]
        public void SuccessfulIsUnderwayTest()
        {
            var underway = new ShipTest { NavigationalStatus = NavigationalStatus.Underway };

            Assert.IsTrue(
                underway.IsUnderway()
            );
        }

        /// <summary>
        /// Ship reports navigational status as something other than underway.
        /// </summary>
        [TestMethod]
        public void SuccessfulIsNotUnderwayTest()
        {
            var underway = new ShipTest { NavigationalStatus = NavigationalStatus.Other };

            Assert.IsFalse(
                underway.IsUnderway()
            );
        }

        /// <summary>
        /// Checks if ship bearing is within ninety degrees of the port of Duluth
        /// Ship A is in St. Louis Bay
        /// Ship B is above the peninsula of Wisconsin, out in Lake Superior
        /// </summary>
        [TestMethod]
        public void SuccessfulIsMovingTowardDuluthTest()
        {
            var ship = new[]
            {
                new ShipTest { Position = new Position("ShipA0", 46.737640, -92.138895), Heading = 0 },
                new ShipTest { Position = new Position("ShipA90", 46.737640, -92.138895), Heading = 90 },
                new ShipTest { Position = new Position("ShipB180", 47.589057, -86.763969), Heading = 180 },
                new ShipTest { Position = new Position("ShipB270", 47.589057, -86.763969), Heading = 270 }
            };

            foreach (var s in ship)
            {
                Assert.IsTrue(s.IsMovingToward(Ports.Duluth));
            }
        }

        /// <summary>
        /// Checks if a ship must turn more than ninety degrees to be on course for port of Duluth
        /// Ship A is in St. Louis Bay
        /// Ship B is above the peninsula of Wisconsin, out in Lake Superior
        /// </summary>
        [TestMethod]
        public void SuccessfulIsNotMovingTowardDuluthTest()
        {
            var ship = new[]
            {
                new ShipTest { Position = new Position("ShipA180", 46.737640, -92.138895), Heading = 180 },
                new ShipTest { Position = new Position("ShipA2270", 46.737640, -92.138895), Heading = 270 },
                new ShipTest { Position = new Position("ShipB0", 47.589057, -86.763969), Heading = 0 },
                new ShipTest { Position = new Position("ShipB90", 47.589057, -86.763969), Heading = 90 }
            };

            foreach (var s in ship)
            {
                Assert.IsFalse(s.IsMovingToward(Ports.Duluth));
            }
        }

        /// <summary>
        /// Checks if the bearing of a ship is within a 2/3 threshold of the difference between the two nearest ports
        /// Ship B is above the peninsula of Wisconsin, out in Lake Superior
        /// Ship C is right outside Duluth Canal
        /// Ship D is north of Two Harbors
        /// </summary>
        [TestMethod]
        public void SuccessfulIsHeadingTowardDuluthTest()
        {
            var ship = new[]
            {
                new ShipTest { Position = new Position("ShipB180", 47.589057, -86.763969), Heading = 180 },
                new ShipTest { Position = new Position("ShipB270", 47.589057, -86.763969), Heading = 270 },
                new ShipTest { Position = new Position("ShipC270", 46.780696, -92.046391), Heading = 300 },
                new ShipTest { Position = new Position("ShipC270", 46.780696, -92.046391), Heading = 210 },
                new ShipTest { Position = new Position("ShipD230", 47.103228, -91.461197), Heading = 230 },
                new ShipTest { Position = new Position("ShipD320", 47.103228, -91.461197), Heading = 320 }
            };

            foreach (var s in ship)
            {
                Assert.IsTrue(s.IsMovingToward(Ports.Duluth));
            }
        }

        /// <summary>
        /// Checks if the bearing of a ship is not within a 2/3 threshold of the difference between the two nearest ports
        /// Ship B is above the peninsula of Wisconsin, out in Lake Superior
        /// Ship C is right outside Duluth Canal 
        /// Ship D is north of Two Harbors
        /// </summary>
        [TestMethod]
        public void SuccessfulIsNotHeadingTowardDuluthTest()
        {
            var ship = new[]
            {
                new ShipTest { Position = new Position("ShipB0", 47.589057, -86.763969), Heading = 0 },
                new ShipTest { Position = new Position("ShipB90", 47.589057, -86.763969), Heading = 90 },
                new ShipTest { Position = new Position("ShipC270", 46.780696, -92.046391), Heading = 30 },
                new ShipTest { Position = new Position("ShipC270", 46.780696, -92.046391), Heading = 120 },
                new ShipTest { Position = new Position("ShipD50", 47.103228, -91.461197), Heading = 50 },
                new ShipTest { Position = new Position("ShipD140", 47.103228, -91.461197), Heading = 140 }
            };

            foreach (var s in ship)
            {
                Assert.IsFalse(s.IsMovingToward(Ports.Duluth));
            }
        }

        /// <summary>
        /// Is a ship in Duluth Superior Harbor for more than one hour?
        /// </summary>
        [TestMethod]
        public void SuccessfulIsInDuluthSuperiorHarborForMoreThanHourTest()
        {
            var dayOldShipsInHarbor = new[]
            {
                new ShipTest { Position = new Position("ShipD", 46.771041, -92.097696), CanalEntryTimestamp = DateTime.Now.AddDays(-1) },
                new ShipTest { Position = new Position("ShipE", 46.731052, -92.068857), CanalEntryTimestamp = DateTime.Now.AddDays(-1) },
                new ShipTest { Position = new Position("ShipG", 46.753887, -92.079929), CanalEntryTimestamp = DateTime.Now.AddDays(-1) },
                new ShipTest { Position = new Position("ShipH", 46.739889, -92.134861), CanalEntryTimestamp = DateTime.Now.AddDays(-1) }
            };

            foreach (var s in dayOldShipsInHarbor)
            {
                Assert.IsTrue(
                    s.IsInDuluthSuperiorHarborForMoreThanHour()
                );
            } 
        }

        /// <summary>
        /// Is a ship in Duluth Superior Harbor for less than one hour?
        /// </summary>
        [TestMethod]
        public void SuccessfulIsNotInDuluthSuperiorHarborForMoreThanHourTest()
        {
            var newShipsInHarbor = new[]
            {
                new ShipTest { Position = new Position("ShipD", 46.771041, -92.097696), CanalEntryTimestamp = DateTime.Now.AddHours(6) },
                new ShipTest { Position = new Position("ShipE", 46.731052, -92.068857), CanalEntryTimestamp = DateTime.Now.AddHours(6) },
                new ShipTest { Position = new Position("ShipG", 46.753887, -92.079929), CanalEntryTimestamp = DateTime.Now.AddHours(6) },
                new ShipTest { Position = new Position("ShipH", 46.739889, -92.134861), CanalEntryTimestamp = DateTime.Now.AddHours(6) }
            };

            foreach (var s in newShipsInHarbor)
            {
                Assert.IsFalse(
                    s.IsInDuluthSuperiorHarborForMoreThanHour()
                );
            }  
        }
    }
}