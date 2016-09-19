//-----------------------------------------------------------------------
// <copyright file="IView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _3.Triangle.View
{
    using System.Collections.Generic;
    using Entities;

    /// <summary>
    /// It is an interface for displaying result collection of triangles.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// It is a method for displaying result collection of triangles.
        /// </summary>
        /// <param name="triangles">Collection of triangles.</param>
        void DisplayData(ICollection<Triangle> triangles);

        /// <summary>
        /// Method to display message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        void Dislay(string message);
    }
}
