//-----------------------------------------------------------------------
// <copyright file="IParse.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _4.FileParser.Parsers
{
    /// <summary>
    /// Interface for Parsing.
    /// </summary>
    public interface IParse
    {
        /// <summary>
        /// Method counts amount of entries of given strings 
        /// to the given file.
        /// </summary>
        /// <returns>
        /// Quantity of entries one given string to another given string.
        /// </returns>
        int Count();

        /// <summary>
        /// Method Swaps strings in the given file.
        /// </summary>
        void Replace();
    }
}
