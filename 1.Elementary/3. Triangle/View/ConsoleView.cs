//-----------------------------------------------------------------------
// <copyright file="ConsoleView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _3.Triangle.View
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Entities;
    using Properties;

    /// <summary>
    /// It is a class for displaying result collection of triangles.
    /// </summary>
    public class ConsoleView : IView
    {
        /// <summary>
        /// Method to display message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public void Dislay(string message)
        {
            Console.WriteLine(
                Resources.Display,
                message,
                CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// It is a method for displaying result collection of triangles.
        /// </summary>
        /// <param name="triangles">Collection of triangles.</param>
        public void DisplayData(ICollection<Triangle> triangles)
        {
            Console.WriteLine(Resources.Header);
            int i = 0;
            foreach (Triangle triangle in triangles)
            {
                i++;
                Console.WriteLine(
                    Resources.ShowTwoParam,
                    i,
                    triangle,
                    CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Reading user answer.
        /// </summary>
        /// <returns>User answer.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
