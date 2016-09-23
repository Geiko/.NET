//-----------------------------------------------------------------------
// <copyright file="MoscowCounting.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _6.HappyTicket.Entities.AlgorithmTypes
{
    /// <summary>
    /// Class for Moscow algorithm counting.
    /// </summary>
    public class MoscowCounting : ICounting
    {
        /// <summary>
        /// Method of counting digits.
        /// </summary>
        /// <param name="number">Ticket number</param>
        /// <returns>Happy or not.</returns>
        public bool IsHappy(int number)
        {
            int firstSum = 0;
            int lastSum = 0;

            for (int i = 0; i < Ticket.DigitQuantity; i++, number /= 10)
            {
                if (i < Ticket.DigitQuantity / 2)
                {
                    firstSum += number % 10;
                }
                else
                {
                    lastSum += number % 10;
                }
            }

            return firstSum == lastSum;
        }
    }
}
