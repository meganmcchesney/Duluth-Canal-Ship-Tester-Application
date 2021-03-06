﻿namespace ShipTester.Permutation
{
    using System;
    using System.Collections.Generic;
    using Extensions;

    /// <summary>
    /// Collects and ensures creation all ship test permutator properties
    /// </summary>
    /// <typeparam name="TValue">ship test permutator class</typeparam>
    /// <typeparam name="TResult">ship test</typeparam>
    public abstract class Permutator<TValue, TResult> : IPermutator<TResult>
    {
        /// <summary>
        /// Gets or sets Create property for an enumerable list of permutations
        /// </summary>
        public Func<IEnumerable<TResult>> Create { get; set; }

        /// <summary>
        /// Gets or sets Action type, Permute, that does not return a value
        /// </summary>
        public Action<TValue, TResult> Permute { get; set; }

        /// <summary>
        /// Gets ship test permutation case by case
        /// </summary>
        /// <returns>permutations of Ship Test Permutator properties</returns>
        public IEnumerable<TResult> GetPermutations()
        {
            foreach (var permutation in this.CreateInputPermutations())
            {
                var cloneable = permutation.Serialize();

                foreach (var value in this.GetValues())
                {
                    var clone = cloneable.Deserialize<TResult>();
                    if (this.Permute != null)
                        this.Permute(value, clone);
                    yield return clone;
                }
            }
        }

        /// <summary>
        /// Gets the values of ship test permutations
        /// </summary>
        /// <returns>permutations of Ship Test Permutator properties</returns>
        public abstract IEnumerable<TValue> GetValues();

        /// <summary>
        /// If permutations of ship test permutator do not exist, it will create and activate the creation of new permutations
        /// </summary>
        /// <returns>ship test permutations</returns>
        protected virtual IEnumerable<TResult> CreateInputPermutations()
        {
            if (this.Create != null)
                return this.Create();
            return new [] { (TResult)Activator.CreateInstance(typeof(TResult)) };
        }
    }
}
