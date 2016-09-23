//-----------------------------------------------------------------------
// <copyright file="ConsoleDemo.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _7.NumericalSequence.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Properties;

    /// <summary>
    /// Class for displaying info in console.
    /// </summary>
    public class ConsoleDemo : IDemo
    {
        /// <summary>
        /// To show string message.
        /// </summary>
        /// <param name="message">Message for  displaying.</param>
        public void Show(string message)
        {
            Console.WriteLine(
                Resources.Display, 
                message, 
                CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// To show collection numbers.
        /// </summary>
        /// <param name="numbers">Collection for displaying.</param>
        public void Show(ICollection<int> numbers)
        {
            int i = 0;
            foreach (int n in numbers)
            {
                if (i != 0)
                {
                    Console.Write(
                        Resources.Display, 
                        Resources.Comma, 
                        CultureInfo.CurrentCulture);
                }

                Console.Write(
                    Resources.Display, 
                    n.ToString(), 
                    CultureInfo.CurrentCulture);
                i++;
            }

            Console.WriteLine();
        }
    }
}
