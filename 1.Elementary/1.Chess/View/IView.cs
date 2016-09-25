//-----------------------------------------------------------------------
// <copyright file="IView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _1.Chess.View
{
    using Entities;

    /// <summary>
    /// Interface to show info.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Method to show message.
        /// </summary>
        /// <param name="message">Message to show.</param>
        void Display(string message);

        /// <summary>
        /// Method to display given chess board.
        /// </summary>
        /// <param name="cells">
        /// Boolean 2-size array of chess board object.
        /// </param>
        void Display(bool[,] cells);
    }
}
