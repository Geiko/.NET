//-----------------------------------------------------------------------
// <copyright file="ConsoleDemo.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _4.FileParser.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class shows message to Console.
    /// </summary>
    public class ConsoleDemo : IDemo
    {
        /// <summary>
        /// It shows message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public void Display(string message)
        {
            this.ValidateMassege(message);
            Console.WriteLine(message, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// It displays quantity of entries one given string 
        /// to another given string.
        /// </summary>
        /// <param name="stringEntries">
        /// Quantity of entries given string into other given string.
        /// </param>
        public void Display(int stringEntries)
        {
            this.ValidateEntries(stringEntries);
            Console.WriteLine(
                    Properties.Resources.ENTERS_AMOUNT, 
                    stringEntries, 
                    CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// It checks message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        private void ValidateMassege(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(string.Format(
                        Properties.Resources.STRING_NULL_EMPTY, 
                        CultureInfo.CurrentCulture));
            }
        }

        /// <summary>
        /// It validates input integer.
        /// </summary>
        /// <param name="stringEntries">
        /// Quantity of entries given string into other given string.
        /// </param>
        private void ValidateEntries(int stringEntries)
        {
            if (stringEntries < 0)
            {
                throw new ArgumentOutOfRangeException(
                        Properties.Resources.ARGUMENT_LESS_ZERO);
            }
        }
    }
}
