//-----------------------------------------------------------------------
// <copyright file="IView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _6.HappyTicket.View
{
    using Entities.AlgorithmTypes;

    /// <summary>
    /// Interface to show information.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Method to show a message.
        /// </summary>
        /// <param name="message">Message to show.</param>
        void Show(string message);

        /// <summary>
        /// Method to show result.
        /// </summary>
        /// <param name="happyTicketQuantity">
        /// Total quantity of happy tickets.
        /// </param>
        /// <param name="algorithm">Type of used algorithm.</param>
        void ShowResult(int happyTicketQuantity, Algorithm algorithm);

        /// <summary>
        /// Reading user answer.
        /// </summary>
        /// <returns>User answer.</returns>
        string ReadLine();
    }
}
