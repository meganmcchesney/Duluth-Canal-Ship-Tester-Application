namespace ShipTester.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Operations on type string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Strings are joined with a comma
        /// </summary>
        private const string Seperator = ",";

        /// <summary>
        /// Joins objects of type string around a seperator
        /// </summary>
        /// <param name="objects">any object of type string</param>
        /// <param name="seperator">constant, defined above</param>
        /// <returns>Joined string</returns>
        public static string Join(this IEnumerable<object> objects, string seperator = Seperator)
        {
            return string.Join(seperator, objects.ToArray());
        }
    }
}
