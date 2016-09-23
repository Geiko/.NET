//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _2.Envelope
{
    using System;
    using Entities;
    using View;

    /// <summary>
    /// This class represents Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// It is an entry point.
        /// </summary>
        public static void Main()
        {
            IView view = new ConsoleView();
            try
            {
                EnvelopeManager manager = new EnvelopeManager();
                manager.Start();
            }
            catch (OutOfMemoryException ex)
            {
                view.Display(ex.Message);
            }
            catch (SystemException ex)
            {
                view.Display(ex.Message);
            }
        }
    }
}
