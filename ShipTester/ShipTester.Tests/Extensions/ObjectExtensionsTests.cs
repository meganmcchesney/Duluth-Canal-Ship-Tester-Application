namespace ShipTester.Tests.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ShipTester.Extensions;

    /// <summary>
    /// The responsibility of this class is to test the functionality of the ObjectExtensions class
    /// </summary>
    [TestClass]
    public class ObjectExtensionsTests
    {
        /// <summary>
        /// Public property values should be returned as a comma separated string.
        /// </summary>
        [TestMethod]
        public void CommaSeparateObjectPublicPropertiesPrimitive()
        {
            var expected = "1,2";
            var actual = new { Property1 = 1, Property2 = 2 }.PropertyValuesToCsv();
            Assert.AreEqual(expected, actual);
        }
    }
}
