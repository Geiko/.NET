//-----------------------------------------------------------------------
// <copyright file="ConsoleDemo.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number.Demo
{
    using System;
    using System.IO;
    using Properties;

    /// <summary>
    /// Class for displaying info.
    /// </summary>
    public class ConsoleDemo : IDemo
    {
        /// <summary>
        /// Path to the specification file.
        /// </summary>
        private const string SPECIFICATION =
                @"..\..\TextFiles\specification.txt";

        /// <summary>
        /// Method to show specification.
        /// </summary>
        public void ShowSpecification()
        {
            try
            {
                string specification = File.ReadAllText(SPECIFICATION);
            }
            catch (IOException ex)
            {
                throw new IOException(string.Format(
                    Resources.ReadingSpecificationError, ex.Message));
            }
        }

        /// <summary>
        /// Method to display message.
        /// </summary>
        /// <param name="message">Message to show.</param>
        public void Show(string message)
        {
            this.ValidateString(message);
            Console.WriteLine(Resources.Display, message);
        }

        /// <summary>
        /// Method to validate the string.
        /// </summary>
        /// <param name="message">String to validate.</param>
        private void ValidateString(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(string.Format(
                        Resources.MessageEmpty, message));
            }
        }
    }
}
