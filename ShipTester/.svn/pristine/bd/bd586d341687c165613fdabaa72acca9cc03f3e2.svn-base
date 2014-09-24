namespace ShipTester.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Permutation;

    /// <summary>
    /// As the ship test builds its permutations, the extensions class will perform maintenance operations on the list
    /// </summary>
    public static class PermutationExtensions
    {
        /// <summary>
        /// Returns last test case from permutations
        /// </summary>
        /// <param name="source">A single, complete test case of ship test permutations</param>
        /// <typeparam name="T">ship Test</typeparam>
        /// <returns>Removes current test case and moves on to next case</returns>
        /// <exception cref="InvalidOperationException">Source must include ship test permutations</exception>
        public static IEnumerable<T> GetPermutations<T>(this IEnumerable<IPermutator<T>> source)
        {
            var permutators = source.ToList();

            if (permutators.Count == 0)
                throw new InvalidOperationException("The source must not be empty.");

            var last = permutators.Last();

            if (permutators.Count == 1)
                return last.GetPermutations();

            permutators.Remove(last);
            last.Create = () => permutators.GetPermutations();
            return last.GetPermutations();
        }
    }
}
