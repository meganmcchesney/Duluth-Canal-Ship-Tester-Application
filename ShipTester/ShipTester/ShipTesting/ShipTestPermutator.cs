﻿namespace ShipTester.ShipTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ShipTester.Extensions;
    using ShipTester.Model;
    using ShipTester.Permutation;

    /// <summary>
    /// Defines the permutations of ship test objects
    /// </summary>
    public static class ShipTestPermutator
    {
        /// <summary>
        /// Gets sets of ship test object permutations for test
        /// </summary>
        /// <returns>ship test object permutations</returns>
        public static IEnumerable<ShipTest> GetShipTests()
        {
            return new IPermutator<ShipTest>[] {
                new EnumerablePermutator<double, ShipTest> {
                    Values = new [] { 12.5 },
                    Permute = (speed, shipTest) => shipTest.Speed = speed
                },
                new EnumerablePermutator<NavigationalStatus, ShipTest> {
                    Values = Enum.GetValues(typeof(NavigationalStatus)).Cast<NavigationalStatus>(),
                    Permute = (navStatus, shipTest) => shipTest.NavigationalStatus = navStatus
                },
                new EnumerablePermutator<Position, ShipTest> {
                    Values = ShipPositions.All,
                    Permute = (position, shipTest) => shipTest.Position = position
                },
                new EnumerablePermutator<int, ShipTest> {
                    Values = Enumerable.Range(240, 20),
                    Permute = (i, shipTest) => shipTest.Heading = i
                },
                new EnumerablePermutator<Position, ShipTest> {
                    Values = Ports.All,
                    Permute = (port, shipTest) => shipTest.Destination = port
                }
            }.GetPermutations();
        }
    }
}
