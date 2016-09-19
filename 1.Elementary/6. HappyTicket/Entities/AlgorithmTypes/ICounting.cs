//-----------------------------------------------------------------------
// <copyright file="ICounting.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _6.HappyTicket.Entities.AlgorithmTypes
{
    /// <summary>
    /// Interface for Counters
    /// </summary>
    public interface ICounting
    {
        /// <summary>
        /// Method to determine is this ticket happy.
        /// </summary>
        /// <param name="number">Ticket number</param>
        /// <returns>Happy or not.</returns>
        bool IsHappy(int number);
    }
}
