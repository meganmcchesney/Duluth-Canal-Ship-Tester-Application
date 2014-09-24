namespace ShipTester.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShipTester.Extensions;
    using TestUtilities;

    /// <summary>
    /// The string extension tests.
    /// </summary>
    public class StringExtensionTests
    {
        /// <summary>
        /// The string extensions join tests.
        /// </summary>
        [TestClass]
        public class StringExtensionsJoinTests
        {
            /// <summary>
            /// The successful join test!
            /// </summary>
            [TestMethod]
            public void SuccessfulJoinTest()
            {
                Assert.AreEqual(
                    "One,Two,Three",
                    new[] { "One", "Two", "Three" }.Join()
                );
            }

            /// <summary>
            /// The unsuccessful join test.
            /// </summary>
            [TestMethod]
            public void UnsuccessfulJoinTest()
            {
                IEnumerable<string> input = null;
                // ReSharper disable once ExpressionIsAlwaysNull
                ExceptionAssert.Throws<ArgumentNullException>(() => input.Join());
            }
        }
    }
}