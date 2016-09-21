//-----------------------------------------------------------------------
// <copyright file="EnvelopeManager.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _2.Envelope.Entities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Properties;
    using View;

    /// <summary>
    /// It is class for main action.
    /// </summary>
    public class EnvelopeManager
    {
        /// <summary>
        /// Field for path to the specification file;
        /// </summary>
        private const string SPECIFICATION = 
                @"..\..\TextFiles\Specification.txt";

        /// <summary>
        /// It is constanta for amount of envelopes to compare.
        /// </summary>
        private const int ENVELOPEQUANTITY = 2;

        /// <summary>
        /// It is field for interface reference to collection of envelopes.
        /// </summary>
        private ICollection<Envelope> envelops;

        /// <summary>
        /// It is an interface reference to object that shows result.
        /// </summary>
        private IView view;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EnvelopeManager" /> class.
        /// Structure of the method to compare the envelopes;
        /// </summary>
        public EnvelopeManager()
        {
            this.view = new ConsoleView();
            this.view.Display(File.ReadAllText(SPECIFICATION));
        }

        /// <summary>
        /// Method that is managing envelopes.
        /// </summary>
        public void Start()
        {
            while (true)
            {
                this.envelops = new List<Envelope>(ENVELOPEQUANTITY);
                try
                {
                    this.GettingEnvelopes();
                }
                catch (ArgumentException ex)
                {
                    this.view.Display(ex.Message);
                    continue;
                }

                this.Nesting();
                if (this.IsContinue() == false)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// It is a method to get a collection of envelopes from a user.
        /// </summary>
        private void GettingEnvelopes()
        {
            for (int i = 0; i < ENVELOPEQUANTITY; i++)
            {
                this.view.Display(string.Format(Resources.Envelope, i + 1));
                Envelope? envelope = this.InputEnvelopeParams();
                if (envelope == null)
                {
                    throw new ArgumentNullException(Resources.NoEnvelope);
                }

                this.envelops.Add((Envelope)envelope);
            }
        }

        /// <summary>
        /// It is a method to get one envelope from a user.
        /// </summary>
        /// <returns>It is an object of an envelope.</returns>
        private Envelope? InputEnvelopeParams()
        {
            double? a = this.InputSide();
            if (a != null)
            {
                double? b = this.InputSide();
                if (b != null)
                {
                    return new Envelope((double)a, (double)b);
                }
            }

            return null;
        }

        /// <summary>
        /// This is a method to get one piece of size from user.
        /// </summary>
        /// <returns>It is a User's size of the side.</returns>
        private double? InputSide()
        {
            while (true)
            {
                this.view.Display(Resources.Input);
                string customerSize = this.view.ReadLine();
                if (customerSize == "out")
                {
                    this.view.Display(Resources.By);
                    return null;
                }

                double number;
                bool result = double.TryParse(customerSize, out number);
                if (result == true)
                {
                    return number;
                }

                this.view.Display(
                    string.Format(Resources.NotValid, customerSize));
            }
        }

        /// <summary>
        /// It is a method to compare envelops and show a result.
        /// </summary>
        private void Nesting()
        {
            var envelops = this.envelops as List<Envelope>;            
            if (envelops[0].CompareTo(envelops[1]) < 0)
            {
                this.view.FirstNested(envelops[0], envelops[1]);
            }
            else if (envelops[0].CompareTo(envelops[1]) > 0)
            {
                this.view.SecondNested(envelops[0], envelops[1]);
            }
            else
            {
                this.view.NoNested(envelops[0], envelops[1]);
            }
        }

        /// <summary>
        /// It is a method to ask user does he like continue.
        /// </summary>
        /// <returns>It is a User answer does he like to continue.</returns>
        private bool IsContinue()
        {
            this.view.Display(Resources.Continue);
            string answer = this.view.ReadLine();
            if (answer.ToLower() == "y" || answer.ToLower() == "yes")
            {
                return true;
            }

            return false;
        }
    }
}
