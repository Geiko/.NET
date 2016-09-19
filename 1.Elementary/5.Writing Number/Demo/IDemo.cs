//-----------------------------------------------------------------------
// <copyright file="IDemo.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number.Demo
{
    /// <summary>
    /// Interface to display info.
    /// </summary>
    public interface IDemo
    {
        /// <summary>
        /// Method to show specification.
        /// </summary>
        void ShowSpecification();

        /// <summary>
        /// Method to showa  message.
        /// </summary>
        /// <param name="message">Method to show message.</param>
        void Show(string message);
    }
}
