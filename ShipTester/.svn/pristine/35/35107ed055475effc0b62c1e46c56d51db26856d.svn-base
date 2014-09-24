namespace ShipTester.Tests.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShipTester.Extensions;

    /// <summary>
    /// The double extensions radians and degree tests.
    /// </summary>
    [TestClass]
    public class DoubleExtensionTests
    {
        /// <summary>
        /// The successful radians test.
        /// </summary>
        [TestMethod]
        public void SuccessfulRadianTest()
        {
            var numbers = Enumerable.Range(0, 360);
            foreach (var i in numbers)
            {
                var input = i;
                var expected = i * Math.PI / 180;
                var actual = DoubleExtensions.ToRadians(input);
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// The negative radians test.
        /// </summary>
        [TestMethod]
        public void NegativeOutsideRangeRadianTest()
        {
            const int I = -145;
            const double Expected = I * Math.PI / 180;
            var actual = DoubleExtensions.ToRadians(I);
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        /// The outside range radians test.
        /// </summary>
        [TestMethod]
        public void PositiveOutsideRangeRadianTest()
        {
            const int I = 456;
            const double Expected = I * Math.PI / 180;
            var actual = DoubleExtensions.ToRadians(I);
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        /// The successful degrees test.
        /// </summary>
        [TestMethod]
        public void SuccessfulDegreeTest()
        {
            var degrees = Enumerable.Range(0, 360);
            foreach (var i in degrees)
            {
                var input = i;
                var expected = i * 180 / Math.PI;
                var actual = DoubleExtensions.ToDegrees(input);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}