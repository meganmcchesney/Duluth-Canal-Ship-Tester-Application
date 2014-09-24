namespace ShipTester.Tests.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShipTester.Extensions;
    using ShipTester.Tests.TestUtilities.ReflectionTestClasses;

    /// <summary>
    /// This class is responsible for testing the TypeExtensions class
    /// </summary>
    [TestClass]
    public class TypeExtensionsTests
    {
        /// <summary>
        /// Non-null, public static values of a given type should be retrievable from any type
        /// </summary>
        [TestMethod]
        public void GetFieldValues()
        {
            CollectionAssert.AreEquivalent(
                new [] { 2 },
                typeof(TestClassForFields).GetFieldValues<int>()
            );
        }

        /// <summary>
        /// Public property names should be retrievable as a comma separated string
        /// </summary>
        [TestMethod]
        public void GetPropertyNamesAsCsv()
        {
            Assert.AreEqual(
                "Property1,Property2",
                new { Property1 = 1, Property2 = 2 }.GetType().PropertyNamesToCsv()
            );
        }
    }
}
