//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _7.NumericalSequence
{
    using System;
    using System.IO;
    using System.Linq;
    using Abstract;
    using Demo;
    using GetNumericalSequences;
    using Properties;

    /// <summary>
    /// This class represents Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Array of strings from command prompt.</param>
        public static void Main(string[] args)
        {
            IDemo demo = new ConsoleDemo();
            try
            {
                int argsQuantity = args.Count();
                if (argsQuantity == 0)
                {
                    demo.Show(Resources.NoArgs);
                }
                else
                {
                    INumericalSequence sequanse = new NaturalSequence();
                    for (int i = 0; i < argsQuantity; i++)
                    {
                        demo.Show(string.Format(Resources.Arg, args[i]));
                    }

                    if (argsQuantity == 1)
                    {
                        sequanse = new NaturalSequence(args[0]);
                        demo.Show(sequanse.GetSequence());
                    }
                    else if (argsQuantity == 2)
                    {
                        sequanse = new FibonacciSequence(args[0], args[1]);
                        demo.Show(sequanse.GetSequence());
                    }
                }
            }
            catch (ArgumentException ex)
            {
                demo.Show(ex.Message);
            }
            catch (IOException ex)
            {
                demo.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                demo.Show(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                demo.Show(ex.Message);
            }
            catch (SystemException ex)
            {
                demo.Show(ex.Message);
            }
        }
    }
}