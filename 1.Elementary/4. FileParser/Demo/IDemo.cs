//-----------------------------------------------------------------------
// <copyright file="IDemo.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _4.FileParser.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for displaying info.
    /// </summary>
    public interface IDemo
    {
        /// <summary>
        /// Method for displaying string.
        /// </summary>
        /// <param name="message">Message to display.</param>
        void Display(string message);

        /// <summary>
        /// Method for displaying integer.
        /// </summary>
        /// <param name="stringEntries">
        /// Quantity of entries given string into other given string.
        /// </param>
        void Display(int stringEntries);
    }
}
