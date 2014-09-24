namespace ShipTester.Tests.TestUtilities
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test for exceptions
    /// </summary>
    public static class ExceptionAssert
    {
        /// <summary>
        /// Asserts that the specified type of exception is thrown by a given Action.
        /// </summary>
        /// <typeparam name="T">The type of exception expected to be thrown.</typeparam>
        /// <param name="func">The Action that is expected to throw the given exception.</param>
        /// <exception cref="AssertFailedException">Exception thrown text</exception>
        public static void Throws<T>(Action func) where T : Exception
        {
            var exceptionThrown = false;
            try
            {
                func.Invoke();
            }
            catch (T)
            {
                exceptionThrown = true;
            }

            if (!exceptionThrown)
            {
                throw new AssertFailedException(string.Format("An exception of type {0} was expected, but not thrown", typeof(T)));
            }
        }
    }
}