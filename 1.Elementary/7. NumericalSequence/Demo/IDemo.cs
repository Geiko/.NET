//-----------------------------------------------------------------------
// <copyright file="IDemo.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _7.NumericalSequence.Demo
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for displaying info in console.
    /// </summary>
    public interface IDemo
    {
        /// <summary>
        /// To show string message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        void Show(string message);

        /// <summary>
        /// Method for displaying collection of numbers.
        /// </summary>
        /// <param name="numbers">Collection of numbers.</param>
        void Show(ICollection<int> numbers);
    }
}
