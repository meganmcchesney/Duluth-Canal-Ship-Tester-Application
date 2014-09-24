﻿namespace ShipTester.Helper
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using Model;

    /// <summary>
    /// Methods needed for the calculation of ship position relative to ports.
    /// </summary>
    public static class GeoHelper
    {
        #region distance constants
        /// <summary>
        ///  measure of earth's radius in miles
        ///  http://www.wolframalpha.com/input/?i=radius%20of%20earth
        /// </summary>
        public const double EarthRadiusMiles = 3956.5467;

        /// <summary>
        /// measure of earth's radius in kilometers
        /// </summary>
        public const double EarthRadiusKm = 6367.4447;

        /// <summary>
        /// measure of earth's radius in nautical miles
        /// </summary>
        public const double EarthRadiusNmi = 3438.1451;
        #endregion

        /// <summary>
        /// Distance calculations can be performed in KM, M, or NMi
        /// </summary>
        public enum Units
        {
            /// <summary>
            /// Metric unit of measurement
            /// </summary>
            KiloMeter,

            /// <summary>
            /// Imperial unit of measurement
            /// </summary>
            Miles,

            /// <summary>
            /// Nautical unit of measurement
            /// </summary>
            NauticalMiles
        }

        /// <summary>
        /// Returns bearing to port (definition bearing: degree measure a ship must follow to a defined position)
        /// </summary>
        /// <param name="ship">ship position</param>
        /// <param name="port">port position</param>
        /// <returns>radian measure of ship's bearing to port</returns>
        public static double GetBearing(Position ship, Position port)
        {
            // Algorithm courtesy of Chris Veness
            // http://www.movable-type.co.uk/scripts/latlong.html
            var φ1 = ship.Latitude.ToRadians();
            var φ2 = port.Latitude.ToRadians();
            var δλ = (port.Longitude - ship.Longitude).ToRadians();

            var y = Math.Sin(δλ) * Math.Cos(φ2);
            var x = (Math.Cos(φ1) * Math.Sin(φ2)) -
                    (Math.Sin(φ1) * Math.Cos(φ2) * Math.Cos(δλ));
            var θ = Math.Atan2(y, x);

            return (θ.ToDegrees() + 360) % 360;
        }

        /// <summary>
        /// Method to determine if a given position is inside a defined geographical area
        /// </summary>
        /// <param name="ship">ship position</param>
        /// <param name="area">polygon defined by geographic area</param>
        /// <returns>true / false</returns>
        public static bool IsPointInPolygon(Position ship, Polygon area)
        {
            bool oddNodes = false;
            int j = area.PolySides - 1;

            IList<float> polyY = area.PolyY;
            IList<float> polyX = area.PolyX;

            double x = ship.Longitude;
            double y = ship.Latitude;

            for (int i = 0; i < area.PolySides; i++)
            {
                if ((polyY[i] < y && polyY[j] >= y) || (polyY[j] < y && polyY[i] >= y))
                {
                    if (polyX[i] + ((y - polyY[i]) / (polyY[j] - polyY[i]) * (polyX[j] - polyX[i])) < x)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }

        /// <summary>
        /// Distance between the coordinates. Defaults to using miles unless a unit is specified.
        /// </summary>
        /// <param name="destLatLong">the destination position</param>
        /// <param name="currLatLong">the position of the ship</param>
        /// <param name="unit">optional enum that selects the units, defaults to miles</param>
        /// <returns>approximate distance between to points on a sphere (earth).</returns>
        public static double DistanceBetweenCoord(Position destLatLong, Position currLatLong, Units unit = Units.Miles)
        {
            double radius;

            if (unit == Units.KiloMeter) radius = EarthRadiusKm;
            else if (unit == Units.NauticalMiles) radius = EarthRadiusNmi;
            else radius = EarthRadiusMiles;

            return DistanceBetweenCoord(destLatLong, currLatLong, radius);
        }

        /// <summary>
        /// Distance between the two positions.
        /// </summary>
        /// <param name="destination">The destination position</param>
        /// <param name="shipPosition">the ship position</param>
        /// <param name="radius">the radius of earth</param>
        /// <returns>approximate distance between to points on a sphere (earth)</returns>
        public static double DistanceBetweenCoord(Position destination, Position shipPosition, double radius)
        {
            var destLat = destination.Latitude;
            var destLong = destination.Longitude;
            var currLat = shipPosition.Latitude;
            var currLong = shipPosition.Longitude;

            var φ1 = destLat.ToRadians();
            var φ2 = currLat.ToRadians();
            var δφ = (currLat - destLat).ToRadians();
            var δλ = (currLong - destLong).ToRadians();

            var a = (Math.Sin(δφ / 2) * Math.Sin(δφ / 2)) +
                    (Math.Cos(φ1) * Math.Cos(φ2) *
                    Math.Sin(δλ / 2) * Math.Sin(δλ / 2));
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return radius * c;
        }
    }
}
