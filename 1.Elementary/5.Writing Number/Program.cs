//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number
{
    using System;
    using System.IO;
    using System.Linq;
    using Demo;
    using Properties;
    using Writers;

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
                if (args.Count() == 0)
                {
                    demo.Show(Resources.ArgsIsNull);
                }
                else
                {
                    demo.Show(args[0]);
                    INumberWriter writer = new EngDictionaryRecursWriter(args[0], true);
                    demo.Show(writer.ConvertToText());
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
            catch (SystemException ex)
            {
                demo.Show(ex.Message);
            }
        }
    }
}
