//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _3.Triangle
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
        /// It is entry point.
        /// </summary>
        public static void Main()
        {
            IView view = new ConsoleView();
            try
            {
                TriangleSorting sorting = new TriangleSorting();
                sorting.Start();
            }
            catch (SystemException ex)
            {
                view.Dislay(ex.Message);
            }
        }
    }
}
