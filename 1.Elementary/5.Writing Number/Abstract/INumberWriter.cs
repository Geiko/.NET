//-----------------------------------------------------------------------
// <copyright file="INumberWriter.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number
{
    /// <summary>
    /// Interface for converting number to the word.
    /// </summary>
    public interface INumberWriter
    {
        /// <summary>
        /// Gets or sets number that is got from command prompt.
        /// </summary>
        int NumberToText { get; set; }

        /// <summary>
        /// Main method for converting number to words.
        /// </summary>
        /// <returns>Resulted string.</returns>
        string ConvertToText();
    }
}