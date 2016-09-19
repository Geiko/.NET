//-----------------------------------------------------------------------
// <copyright file="Passenger.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _6.HappyTicket.Entities
{
    using System;
    using System.IO;
    using AlgorithmTypes;
    using Properties;
    using View;

    /// <summary>
    /// Class of manager of counting.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Field for path to the file of specification.
        /// </summary>
        private const string SPECIFICATION =
                @"..\..\TextFiles\Specification.txt";

        /// <summary>
        /// Field for path to the type of algorithm.
        /// </summary>
        private string pathToAlgorithmFile;

        /// <summary>
        /// Reference to interface for display info.
        /// </summary>
        private IView view;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="Passenger" /> class that shows specification.
        /// </summary>
        public Passenger()
        {
            this.view = new ConsoleView();
            this.view.Show(File.ReadAllText(SPECIFICATION));
        }

        /// <summary>
        /// Gets or sets the path to algorithm file.
        /// </summary>
        public string PathToAlgorithmFile
        {
            get
            {
                return this.pathToAlgorithmFile;
            }

            set
            {
                if (!File.Exists(value))
                {
                    throw new ArgumentException(
                            string.Format(Resources.NoFile, value));
                }

                this.pathToAlgorithmFile = value;
            }
        }

        /// <summary>
        /// Asking path to the file with type of counting algorithm.
        /// </summary>
        public void AskAlgorithm()
        {
            this.view.Show(Resources.AskAlgotithm);
        }

        /// <summary>
        /// Method to start application.
        /// </summary>
        public void HowManyHappyNumbersExist()
        {
            Algorithm algorithm = this.DefineAlgorithm();
            this.view.ShowResult(this.Count(algorithm), algorithm);
        }

        /// <summary>
        /// Method to determine type of algorithm.
        /// </summary>
        /// <returns>Type of counting algorithm.</returns>
        private Algorithm DefineAlgorithm()
        {
            string algorithm = File.ReadAllText(this.pathToAlgorithmFile);
            if (algorithm.Trim().ToLower() == "moscow")
            {
                return Algorithm.Moscow;
            }
            else if (algorithm.Trim().ToLower() == "piter")
            {
                return Algorithm.Piter;
            }
            else
            {
                throw new ArgumentNullException(string.Format(
                        Resources.NoAlgorithm, algorithm.ToString()));
            }
        }

        /// <summary>
        /// Method to count happy tickets.
        /// </summary>
        /// <param name="algorithm">The type of counting algorithm.</param>
        /// <returns>Total Quantity of Happy Tickets</returns>
        private int Count(Algorithm algorithm)
        {
            ICounting counting;
            if (algorithm == Algorithm.Moscow)
            {
                counting = new MoscowCounting();
            }
            else if (algorithm == Algorithm.Piter)
            {
                counting = new PiterCounting();
            }
            else
            {
                throw new ArgumentException(
                        Resources.NoAlgorithm, algorithm.ToString());
            }

            Ticket ticket = new Ticket();
            int happyTicketQuantity = 0;
            for (int i = Ticket.MinNumber; i <= Ticket.MaxNumber; i++)
            {
                ticket.Number = i;
                if (counting.IsHappy(ticket.Number))
                {
                    happyTicketQuantity++;
                }
            }

            return happyTicketQuantity;
        }
    }
}