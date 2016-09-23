//-----------------------------------------------------------------------
// <copyright file="PiterCounting.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _6.HappyTicket.Entities.AlgorithmTypes
{
    /// <summary>
    /// Class for Pittsburgh algorithm of counting.
    /// </summary>
    public class PiterCounting : ICounting
    {
        /// <summary>
        /// Method of counting digit
        /// </summary>
        /// <param name="number">Ticket number</param>
        /// <returns>Happy or not.</returns>s.
        public bool IsHappy(int number)
        {
            int firstSum = 0;
            int lastSum = 0;

            for (int i = 0; i < Ticket.DigitQuantity; i++, number /= 10)
            {
                if (i % 2 == 0)
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
