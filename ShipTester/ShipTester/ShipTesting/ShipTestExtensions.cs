﻿namespace ShipTester.ShipTesting
{
    using System;
    using System.Linq;
    using Helper;
    using Model;

    /// <summary>
    /// Methods specific to operations on the ship test object
    /// </summary>
    public static class ShipTestExtensions
    {
        /// <summary>
        /// Uses point in polygon test to determine if a ship is located in the Duluth Superior Harbor
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <returns>true or false</returns>
        public static bool IsInDuluthSuperiorHarbor(this ShipTest shipTest)
        {
            return GeoHelper.IsPointInPolygon(shipTest.Position, Areas.DuluthSuperiorHarbor);
        }

        /// <summary>
        /// If the a ship's bearing to a given position is less than 90 degrees away from exact heading needed to get to the port,
        /// Then we says that a ship is moving toward that port
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <param name="position">Location of port that ship may be moving toward</param>
        /// <returns>true or false</returns>
        public static bool IsMovingToward(this ShipTest shipTest, Position position)
        {
            var bearing = GeoHelper.GetBearing(shipTest.Position, position);
            var difference = Math.Abs(shipTest.Heading - bearing);
            return difference <= 90;
        }

        /// <summary>
        /// Is a ship located in St. Louis Bay?
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <returns>true or false</returns>
        public static bool IsInStLouisBay(this ShipTest shipTest)
        {
            return GeoHelper.IsPointInPolygon(shipTest.Position, Areas.StLouisBay);
        }

        /// <summary>
        /// Does the ship's reported navigational status contain the string "underway"?
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <returns>true or false</returns>
        public static bool IsUnderway(this ShipTest shipTest)
        {
            return shipTest.NavigationalStatus == NavigationalStatus.Underway;
        }

        /// <summary>
        /// Is a ship within 50 miles of the Duluth Canal?
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <returns>true or false</returns>
        public static bool IsWithinFiftyMilesOfDuluth(this ShipTest shipTest)
        {
            return GeoHelper.DistanceBetweenCoord(shipTest.Position, Ports.Duluth) <= 50;
        }

        /// <summary>
        /// Is a ship reporting a destination of Duluth?
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <returns>true or false</returns>
        public static bool IsDestinationDuluth(this ShipTest shipTest)
        {
            return shipTest.Destination == Ports.Duluth;
        }

        /// <summary>
        /// If the a ship's bearing to a given position is less than 90 degrees away from exact heading needed to get to the port,
        /// Then we says that a ship is moving toward that port
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <returns>true or false</returns>
        public static bool IsMovingTowardDuluth(this ShipTest shipTest)
        {
            return shipTest.IsMovingToward(Ports.Duluth);
        }

        /// <summary>
        /// Has a ship been in the Duluth Superior Harbor for more than an hour?
        /// Reasoning: We use this test because ships have a variety of movements inside the harbor.
        /// If a ship has entered the harbor recently, we're going to ignore its movements for a certain length of time
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <returns>true or false</returns>
        public static bool IsInDuluthSuperiorHarborForMoreThanHour(this ShipTest shipTest)
        {
            return shipTest.CanalEntryTimestamp.HasValue && shipTest.CanalEntryTimestamp < DateTime.UtcNow.AddHours(-1);
        }

        /// <summary>
        /// Does the ship's heading put it on course to enter Duluth Canal?
        /// Ships report numerous false destinations. Therefore, we use this method 
        /// to check a ship's actual heading against the bearing to the two nearest ports
        /// and make a determination whether or not the ship will actually use Duluth Canal
        /// </summary>
        /// <param name="shipTest">shipTest object</param>
        /// <returns>true or false</returns>
        public static bool IsHeadingTowardDuluth(this ShipTest shipTest)
        {
            var twoNearestPortsAndBearing = Ports.All.Select(p => {
                var bearing = GeoHelper.GetBearing(shipTest.Position, p);
                var adjustment = Math.Abs(bearing - shipTest.Heading);
                if (adjustment > 180) adjustment = 360 - adjustment;
                return new { 
                    Position = p,
                    Bearing = bearing,
                    Adjustment = adjustment
                };       
             }).OrderBy(
                p => p.Adjustment
             ).Take(2).ToArray();
            
            var firstPort = twoNearestPortsAndBearing[0];
            var secondPort = twoNearestPortsAndBearing[1];

            var portBearingDiff = Math.Abs(firstPort.Bearing - secondPort.Bearing);

            var weight = 1 / 2D;

            if (shipTest.Destination == firstPort.Position)
                weight = 2 / 3D;
            else if (shipTest.Destination == secondPort.Position)
                weight = 1 / 3D;

            var threshold = weight * portBearingDiff;

            Position nearestPort = null;

            if (firstPort.Adjustment <= threshold)
                nearestPort = firstPort.Position;
            else if (secondPort.Adjustment <= threshold)
                nearestPort = secondPort.Position;
            else if (shipTest.IsMovingToward(firstPort.Position))
                nearestPort = firstPort.Position;

            return nearestPort == Ports.Duluth;
        }
    }
}
