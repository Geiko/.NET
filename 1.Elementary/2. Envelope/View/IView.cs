//-----------------------------------------------------------------------
// <copyright file="IView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _2.Envelope.View
{
    using Entities;

    /// <summary>
    /// Interface to show info.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Method to show message.
        /// </summary>
        /// <param name="message">Message to show.</param>
        void Display(string message);

        /// <summary>
        /// This method shows that first envelope is nested to the second.
        /// </summary>
        /// <param name="envelope1">First envelope.</param>
        /// <param name="envelope2">Second envelope.</param>
        void FirstNested(Envelope envelope1, Envelope envelope2);

        /// <summary>
        /// This method shows that second envelope is nested to the first.
        /// </summary>
        /// <param name="envelope1">First envelope.</param>
        /// <param name="envelope2">Second envelope.</param>
        void SecondNested(Envelope envelope1, Envelope envelope2);

        /// <summary>
        /// This method shows that envelops cannot be nested to each other.
        /// </summary>
        /// <param name="envelope1">First envelope.</param>
        /// <param name="envelope2">Second envelope.</param>
        void NoNested(Envelope envelope1, Envelope envelope2);

        /// <summary>
        /// Reading user answer.
        /// </summary>
        /// <returns>User answer.</returns>
        string ReadLine();
    }
}
