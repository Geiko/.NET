//-----------------------------------------------------------------------
// <copyright file="ConsoleView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _2.Envelope.View
{
    using System;
    using Entities;
    using Properties;

    /// <summary>
    /// Class to show info.
    /// </summary>
    public class ConsoleView : IView
    {
        /// <summary>
        /// Method to show message.
        /// </summary>
        /// <param name="message">Message to show.</param>
        public void Display(string message)
        {
            Console.WriteLine(Resources.Show, message);
        }

        /// <summary>
        /// This method shows that first envelope is nested to the second.
        /// </summary>
        /// <param name="envelope1">First envelope.</param>
        /// <param name="envelope2">Second envelope.</param>
        public void FirstNested(Envelope envelope1, Envelope envelope2)
        {
            Console.WriteLine(Resources.Nesting);
            Console.WriteLine(Resources.Envelope1In2, envelope1, envelope2);
        }

        /// <summary>
        /// This method shows that second envelope is nested to the first.
        /// </summary>
        /// <param name="envelope1">First envelope.</param>
        /// <param name="envelope2">Second envelope.</param>
        public void SecondNested(Envelope envelope1, Envelope envelope2)
        {
            Console.WriteLine(Resources.Nesting);
            Console.WriteLine(Resources.Envelope2In1, envelope1, envelope2);
        }

        /// <summary>
        /// This method shows that envelops cannot be nested to each other.
        /// </summary>
        /// <param name="envelope1">First envelope.</param>
        /// <param name="envelope2">Second envelope.</param>
        public void NoNested(Envelope envelope1, Envelope envelope2)
        {
            Console.WriteLine(Resources.Nesting);
            Console.WriteLine(
                Resources.NoEnvelopeInput, envelope1, envelope2);
        }
    }
}