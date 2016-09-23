//-----------------------------------------------------------------------
// <copyright file="Ticket.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _6.HappyTicket.Entities
{
    using System;
    using Properties;

    /// <summary>
    /// Struct for ticket.
    /// </summary>
    public struct Ticket
    {
        /// <summary>
        /// Minimal number for ticket.
        /// </summary>
        public const int MinNumber = 0;

        /// <summary>
        /// Maximal number for ticket.
        /// </summary>
        public const int MaxNumber = 999999;

        /// <summary>
        /// Quantity digits in the number.
        /// </summary>
        public const int DigitQuantity = 6;

        /// <summary>
        /// Field of number.
        /// </summary>
        private int number;

        /// <summary>
        /// Gets or sets the number of the ticket and validate it.
        /// </summary>
        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (value < MinNumber || value > MaxNumber)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(Resources.NumberOut, value));
                }

                this.number = value;
            }
        }
    }
}
