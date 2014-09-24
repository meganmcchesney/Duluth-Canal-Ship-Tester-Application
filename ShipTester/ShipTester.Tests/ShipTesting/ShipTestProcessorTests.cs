namespace ShipTester.Tests.ShipTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShipTester.Extensions;
    using ShipTester.Helper;
    using ShipTester.Model;
    using ShipTester.ShipTesting;

    /// <summary>
    /// The responsibility of this class is to test the functionality of the ShipTestProcessor
    /// </summary>
    [TestClass]
    public class ShipTestProcessorTests
    {
        /// <summary>
        /// Ships in the Duluth/Superior harbor should have a timestamp for canal entry
        /// </summary>
        [TestMethod]
        public void CanalEntryTimestampForShipsInHarbor()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.StLouisBay,
                NavigationalStatus = NavigationalStatus.Other,
                CanalEntryTimestamp = null
            };

            ship.Update();

            DateTime expected = DateTime.UtcNow.AddHours(ShipTestProcessor.CanalEntryTimestampOffset);

            // ReSharper disable once PossibleInvalidOperationException
            Assert.IsTrue(expected > ship.CanalEntryTimestamp.Value.AddSeconds(-1));
            Assert.IsTrue(expected < ship.CanalEntryTimestamp.Value.AddSeconds(1));
        }

        /// <summary>
        /// Ships not in the Duluth/Superior harbor should not have a timestamp for canal entry
        /// </summary>
        [TestMethod]
        public void NoCanalEntryTimestampForShipsNotInHarbor()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.TwentyMilesFromDuluthCanal,
                NavigationalStatus = NavigationalStatus.Other,
                CanalEntryTimestamp = DateTime.UtcNow
            };

            ship.Update();

            Assert.IsNull(ship.CanalEntryTimestamp);
        }

        /// <summary>
        /// Ships that are not underway should not have a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsNotUnderway()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.FiftyMilesFromDuluthCanal,
                NavigationalStatus = NavigationalStatus.Other
            };

            ship.Update();

            Assert.IsNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ships that are more than 50 miles out of Duluth, and appear to be moving toward duluth should rely on the ship's eta
        /// </summary>
        [TestMethod]
        public void ShipsFarOutAndMovingToDuluth()
        {
            var testTime = DateTime.Now;

            var ship = new ShipTest
            {
                Position = ShipPositions.EastLakeSuperior,
                NavigationalStatus = NavigationalStatus.Underway,
                Destination = Ports.Duluth,
                Heading = 200,
                Eta = testTime
            };

            ship.Update();

            Assert.AreEqual(testTime, ship.DerivedEta);
        }

        /// <summary>
        /// Ships that are more than 50 miles out of Duluth which are declaring a destination other than Duluth should not receive a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsFarOutMovingToDuluthButDeclaringOtherwise()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.EastLakeSuperior,
                NavigationalStatus = NavigationalStatus.Underway,
                Destination = Ports.Superior,
                Heading = 200
            };

            ship.Update();

            Assert.IsNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ships that are more than 50 miles out of Duluth and do not appear to be heading to Duluth should not receive a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsFarOutDeclaringDuluthButMovingOtherwise()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.EastLakeSuperior,
                NavigationalStatus = NavigationalStatus.Underway,
                Destination = Ports.Duluth,
                Heading = 45
            };

            ship.Update();

            Assert.IsNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ships that are within 50 miles of Duluth and have a heading toward Duluth, but are not yet in the harbor should receive a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsNearDuluthAndHeadingToDuluth()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.FiftyMilesFromDuluthCanal,
                NavigationalStatus = NavigationalStatus.Underway,
                Destination = Ports.Duluth,
                Heading = 250,
                Speed = 1
            };

            ship.Update();

            Assert.IsNotNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ships that are within 50 miles of Duluth and are not heading toward Duluth should not receive a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsNearDuluthAndNotHeadingToDuluth()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.FiftyMilesFromDuluthCanal,
                NavigationalStatus = NavigationalStatus.Underway,
                Destination = Ports.Duluth,
                Heading = 45
            };

            ship.Update();

            Assert.IsNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ships that have been in the harbor for a short amount of time should not receive a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsRecentlyEnteringTheHarbor()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.StLouisBay,
                NavigationalStatus = NavigationalStatus.Underway,
                CanalEntryTimestamp = DateTime.UtcNow
            };

            ship.Update();

            Assert.IsNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ships that have been in the harbor for a while that are in St. Louis bay should receive a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsInStLouisBayForAPeriodOfTime()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.StLouisBay,
                NavigationalStatus = NavigationalStatus.Underway,
                CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                Speed = 1
            };

            ship.Update();

            Assert.IsNotNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ships that have been in the harbor for a while that are moving toward Duluth should receive a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsInHarborForAPeriodOfTimeHeadingToDuluth()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.DuluthSuperiorDeadZone,
                NavigationalStatus = NavigationalStatus.Underway,
                CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                Speed = 1,
                Heading = 290
            };

            ship.Update();

            Assert.IsNotNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ships that have been in the harbor for a while that are not in St. Louis bay and not moving toward Duluth should not receive a derived eta
        /// </summary>
        [TestMethod]
        public void ShipsInHarborForAPeriodOfTimeNotHeadingToDuluth()
        {
            var ship = new ShipTest
            {
                Position = ShipPositions.DuluthSuperiorDeadZone,
                NavigationalStatus = NavigationalStatus.Underway,
                CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                Speed = 1,
                Heading = 90
            };

            ship.Update();

            Assert.IsNull(ship.DerivedEta);
        }

        /// <summary>
        /// Ship etas from St. Louis bay to Duluth should be based on a triangulation movement from the current position
        /// </summary>
        [TestMethod]
        public void StandardShipEtasFromStLouisBay()
        {
            Position testPosition = ShipPositions.StLouisBay;

            var ship = new ShipTest
            {
                Position = testPosition,
                NavigationalStatus = NavigationalStatus.Underway,
                CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                Speed = 1
            };

            var directDistanceToDuluth = GeoHelper.DistanceBetweenCoord(Ports.Duluth, testPosition);
            var shipSideDistance = directDistanceToDuluth * Math.Sin(60d.ToRadians());
            var canalSideDistance = directDistanceToDuluth * Math.Cos(60d.ToRadians());
            var totalDistance = shipSideDistance + canalSideDistance;

            var expected = DateTime.UtcNow.AddHours(totalDistance / ship.Speed) + ShipTestProcessor.DataLag;

            ship.Update();

            // ReSharper disable once PossibleInvalidOperationException
            Assert.IsTrue(expected > ship.DerivedEta.Value.AddSeconds(-1));
            Assert.IsTrue(expected < ship.DerivedEta.Value.AddSeconds(1));
        }

        /// <summary>
        /// Stationary ships in St. Louis bay should have a maximum eta value
        /// </summary>
        [TestMethod]
        public void StationaryShipsInStLouisBay()
        {
            var testPosition = ShipPositions.StLouisBay;

            var ship = new ShipTest
            {
                Position = testPosition,
                NavigationalStatus = NavigationalStatus.Underway,
                CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                Speed = 0
            };

            ship.Update();

            Assert.AreEqual(DateTime.MaxValue, ship.DerivedEta);
        }

        /// <summary>
        /// Ship etas from standard locations to Duluth should be based on direct travel from current position
        /// </summary>
        [TestMethod]
        public void ShipEtasFromStandardLocations()
        {
            var testPosition = ShipPositions.DuluthSuperiorDeadZone;

            var ship = new ShipTest
            {
                Position = testPosition,
                NavigationalStatus = NavigationalStatus.Underway,
                CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                Speed = 1,
                Heading = 280
            };

            var directDistanceToDuluth = GeoHelper.DistanceBetweenCoord(Ports.Duluth, testPosition);

            var expected = DateTime.UtcNow.AddHours(directDistanceToDuluth / ship.Speed) + ShipTestProcessor.DataLag;

            ship.Update();

            // ReSharper disable once PossibleInvalidOperationException
            Assert.IsTrue(expected > ship.DerivedEta.Value.AddSeconds(-1));
            Assert.IsTrue(expected < ship.DerivedEta.Value.AddSeconds(1));
        }

        /// <summary>
        /// Stationary ships in standard locations should have a maximum eta value
        /// </summary>
        [TestMethod]
        public void StationaryShipsInStandardLocations()
        {
            var testPosition = ShipPositions.DuluthSuperiorDeadZone;

            var ship = new ShipTest
            {
                Position = testPosition,
                NavigationalStatus = NavigationalStatus.Underway,
                CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                Speed = 0,
                Heading = 280
            };

            ship.Update();

            Assert.AreEqual(DateTime.MaxValue, ship.DerivedEta);
        }

        /// <summary>
        /// Ship etas should be able to process in batches
        /// </summary>
        [TestMethod]
        public void ShipDerivedEtaBatches()
        {
            var testPosition = ShipPositions.DuluthSuperiorDeadZone;

            var ships = new List<ShipTest> {
                new ShipTest
                {
                    Position = testPosition,
                    NavigationalStatus = NavigationalStatus.Underway,
                    CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                    Speed = 0,
                    Heading = 280
                },
                new ShipTest
                {
                    Position = testPosition,
                    NavigationalStatus = NavigationalStatus.Underway,
                    CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                    Speed = 0,
                    Heading = 280
                },
                new ShipTest
                {
                    Position = testPosition,
                    NavigationalStatus = NavigationalStatus.Underway,
                    CanalEntryTimestamp = DateTime.UtcNow.AddHours(-6),
                    Speed = 0,
                    Heading = 280
                }
            };

            ships.Execute();

            Assert.IsTrue(ships.All(s => s.DerivedEta.HasValue));
        }
    }
}
