namespace ShipTester.Extensions
{
    using System.Linq;

    /// <summary>
    /// This class extends the functionality of object
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Generates comma separated string of the values of an object's public properties
        /// </summary>
        /// <param name="obj">An object from which to get the values</param>
        /// <typeparam name="T">The type of the object from which to get the values</typeparam>
        /// <returns>A comma separated string of the object's public property values</returns>
        public static string PropertyValuesToCsv<T>(this T obj)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            return properties.Select(p => p.GetValue(obj)).Join();
        }
    }
}
