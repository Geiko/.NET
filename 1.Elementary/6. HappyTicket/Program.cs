//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _6.HappyTicket
{
    using System;
    using System.IO;
    using Entities;
    using View;

    /// <summary>
    /// This class represents Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">
        /// Array of string arguments from command prompt.
        /// </param>
        public static void Main(string[] args)
        {
            IView view = new ConsoleView();
            try
            {
                Passenger passenger = new Passenger();
                passenger.AskAlgorithm();
                string input = view.ReadLine();
                passenger.PathToAlgorithmFile =
                        string.IsNullOrEmpty(input) ?
                        @"..\..\TextFiles\Algorithm.txt" : 
                        input;
                passenger.HowManyHappyNumbersExist();
            }
            catch (ArgumentException ex)
            {
                view.Show(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                view.Show(ex.Message);
            }
        }
    }
}
