//-----------------------------------------------------------------------
// <copyright file="ConsoleView.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _1.Chess.View
{
    using System;
    using Entities;
    using Properties;

    /// <summary>
    /// Class to show info in Console.
    /// </summary>
    public class ConsoleView : IView
    {
        /// <summary>
        /// View of Black cell.
        /// </summary>
        private string blackCell = "*";

        /// <summary>
        /// View of White cell.
        /// </summary>
        private string whiteCell = "  ";

        /// <summary>
        /// Method to display message in Console.
        /// </summary>
        /// <param name="message">Message to show.</param>
        public void Display(string message)
        {
            Console.WriteLine(Resources.Display, message);
        }

        /// <summary>
        /// Method to display board.
        /// </summary>
        /// <param name="board">Object of board.</param>
        public void Display(ChessBoard board)
        {
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.Cells[i, j] == true)
                    {
                        Console.Write(this.blackCell);
                    }
                    else
                    {
                        Console.Write(this.whiteCell);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
