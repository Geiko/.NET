//-----------------------------------------------------------------------
// <copyright file="ConsoleView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _1.Chess.View
{
    using System;
    using System.Globalization;
    using Properties;

    /// <summary>
    /// Class to show info in Console.
    /// </summary>
    public class ConsoleView : IView
    {
        /// <summary>
        /// View of Black cell.
        /// </summary>
        private const string BLACK = "*";

        /// <summary>
        /// View of White cell.
        /// </summary>
        private const string WHITE = "  ";

        /// <summary>
        /// Method to display message in Console.
        /// </summary>
        /// <param name="message">Message to show.</param>
        public void Display(string message)
        {
            Console.WriteLine(
                Resources.Display,
                message, 
                CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Method to display board.
        /// </summary>
        /// <param name="cells">
        /// Boolean 2-size array of chess board object.
        /// </param>
        public void Display(bool[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j] == true)
                    {
                        Console.Write(BLACK);
                    }
                    else
                    {
                        Console.Write(WHITE);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}