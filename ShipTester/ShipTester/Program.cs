namespace ShipTester
{
    using System.Diagnostics;
    using System.Linq;

    using ShipTester.ShipTesting;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        private static void Main()
        {
            RunShipTests();
        }

        /// <summary>
        /// The run ship tests.
        /// </summary>
        private static void RunShipTests()
        {
            // Generate a collection of ship tests
            ShipTest[] shipTests = ShipTestPermutator.GetShipTests().ToArray();

            // Process all the ship tests
            ShipTestProcessor.Execute(shipTests);

            // Evaluate all the ship tests
            ShipTestEvaluator.Evaluate(shipTests);

            // miles
            // double test = GeoHelper.DistanceBetweenCoord(ShipPositions.DuluthHarborBasin, ShipPositions.FiftyMilesFromDuluthCanal);
            // KM
            // double test2KM = GeoHelper.DistanceBetweenCoord(ShipPositions.DuluthHarborBasin, ShipPositions.FiftyMilesFromDuluthCanal, 6371);

            // Write out and view the ship tests
            Process.Start("Excel", ShipTestWriter.Write(shipTests));
        }
    }
}