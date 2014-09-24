namespace ShipTester.ShipTesting
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Extensions;

    /// <summary>
    /// Writes ship test to a file
    /// </summary>
    public static class ShipTestWriter
    {
        /// <summary>
        /// Writes ship tests to a csv file
        /// </summary>
        /// <param name="shipTests">list of ship Test permutations</param>
        /// <param name="path">where the file should be saved</param>
        /// <returns>a csv file</returns>
        public static string Write(IEnumerable<ShipTest> shipTests, string path = null)
        {
            if (string.IsNullOrEmpty(path)) {
                path = Path.ChangeExtension(Path.GetTempFileName(), "csv");
            }

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(typeof(ShipTest).PropertyNamesToCsv());
                shipTests.ToList().ForEach(st => writer.WriteLine(st.PropertyValuesToCsv()));
            }

            return path;
        }
    }
}
