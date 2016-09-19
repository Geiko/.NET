//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace Elementary
{
    using System;
    using _1.Chess.Entities;
    using _1.Chess.Properties;
    using _1.Chess.View;

    /// <summary>
    /// This class represents Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Method for entry point.
        /// </summary>
        /// <param name="args">Array of strings from command prompt.</param>
        public static void Main(string[] args)
        {
            IView view = new ConsoleView();
            try
            {
                if (args.Length > 0)
                {
                    if (args.Length >= 2)
                    {
                        ChessBoard board = new ChessBoard();
                        ShowArgs(args, view);
                        board = new ChessBoard(args[0], args[1]);
                        view.Display(board);
                    }
                }
                else
                {
                    view.Display(Resources.NoArgs);
                }
            }
            catch (ArgumentException ex)
            {
                view.Display(ex.Message);
            }
            catch (FormatException ex)
            {
                view.Display(ex.Message);
            }
            catch (OverflowException ex)
            {
                view.Display(ex.Message);
            }
        }

        /// <summary>
        /// Method to show args of command prompt.
        /// </summary>
        /// <param name="args">
        /// Array of strings from the command prompt.
        /// </param>
        /// <param name="view">
        /// Object to show information in Console.
        /// </param>
        private static void ShowArgs(string[] args, IView view)
        {
            view.Display(Resources.Args);
            for (int i = 0; i < args.Length; i++)
            {
                view.Display(args[i]);
            }
        }
    }
}
