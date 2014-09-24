namespace ShipTester.Extensions
{
using System;
using System.Linq;

    /// <summary>
    /// This class defines additional extensions for the Type type.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets all non-null public static fields of a given type from a type.
        /// </summary>
        /// <typeparam name="T">The field type of the static fields to be retrieved from the type</typeparam>
        /// <param name="type">The type from which field values will be retrieved</param>
        /// <returns>An array of objects of the specified field type</returns>
        public static T[] GetFieldValues<T>(this Type type)
        {
            return type
                .GetFields()
                .Where(f => f.IsStatic && f.FieldType == typeof(T))
                .Select(f => f.GetValue(null))
                .Cast<T>()
                .ToArray();
        }

        /// <summary>
        /// Generates comma separated string of the names of an object's properties
        /// </summary>
        /// <param name="type">The type from which to get property names</param>
        /// <returns>A comma separated string of the type's property values</returns>
        public static string PropertyNamesToCsv(this Type type)
        {
            var properties = type.GetProperties();
            return properties.Select(p => p.Name).Join();
        }
    }
}
