namespace ShipTester.Extensions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Provides methods for serializing objects.
    /// </summary>
    public static class SerializationExtensions
    {
        /// <summary>
        /// Serializes the object
        /// </summary>
        /// <param name="identifier">The object being serialized</param>
        /// <returns>A serialized object</returns>
        public static byte[] Serialize(this object identifier)
        {
            if (identifier == null)
                return new byte[0];

            using (var stream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(stream, identifier);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserializes a bit stream
        /// </summary>
        /// <param name="data">the bit stream</param>
        /// <returns>a deserialized object</returns>
        public static object Deserialize(this byte[] data)
        {
            if (data == null || data.Length == 0)
                return null;

            using (var stream = new MemoryStream(data))
                return (new BinaryFormatter()).Deserialize(stream);
        }

        /// <summary>
        /// Deserialize using reflection
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="data">the bit stream to be deserialized</param>
        /// <returns>The object data cast to type T</returns>
        public static T Deserialize<T>(this byte[] data)
        {
            return (T)data.Deserialize();
        }
    }
}
