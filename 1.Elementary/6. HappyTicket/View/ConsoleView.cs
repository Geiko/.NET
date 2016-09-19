//-----------------------------------------------------------------------
// <copyright file="ConsoleView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _6.HappyTicket.View
{
    using System;
    using Entities;
    using Entities.AlgorithmTypes;
    using Properties;

    /// <summary>
    /// Class to show info in console.
    /// </summary>
    public class ConsoleView : IView
    {
        /// <summary>
        /// Method to show message in the console.
        /// </summary>
        /// <param name="message">Message to be shown.</param>
        public void Show(string message)
        {
            Console.WriteLine(Resources.Display, message);
        }
                
        /// <summary>
        /// Method to show result to console.
        /// </summary>
        /// <param name="happyTicketQuantity">
        /// Total quantity of happy tickets.
        /// </param>
        /// <param name="algorithm">Type of used counting.</param>
        public void ShowResult(int happyTicketQuantity, Algorithm algorithm)
        {
            Console.WriteLine(
                Resources.Result, 
                Ticket.MinNumber, 
                Ticket.MaxNumber,
                happyTicketQuantity, 
                algorithm);
        }
    }
}
