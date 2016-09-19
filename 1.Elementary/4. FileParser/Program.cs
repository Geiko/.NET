//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _4.FileParser
{
    using System;
    using System.IO;
    using Demo;
    using Parsers;

    /// <summary>
    /// This class represents Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Array of string from command prompt.</param>
        public static void Main(string[] args)
        {
            IDemo demo = new ConsoleDemo();
            try
            {
                ShowArgs(args, demo);
                string path = @"..\..\TextFiles\my.txt";
                RefreshFile(path, demo);

                if (args.Length == 2)
                {
                    IParse parser = new FileParser(args[0], args[1]);
                    parser = new StreamParser(args[0], args[1]);
                    demo.Display(parser.Count());
                }

                if (args.Length == 3)
                {
                    IParse parser = new FileParser(args[0], args[1], args[2]);
                    parser = new StreamParser(args[0], args[1], args[2]);
                    parser.Replace();
                    demo.Display(Properties.Resources.RESULT);
                    demo.Display(string.Format(
                        Properties.Resources.ONE_ARG, 
                        File.ReadAllText(path)));
                }
            }
            catch (ArgumentNullException ex)
            {
                demo.Display(ex.Message);
            }
            catch (IOException ex)
            {
                demo.Display(ex.Message);
            }
            catch (SystemException ex)
            {
                demo.Display(ex.Message);
            }
        }

        /// <summary>
        /// It shows the arguments of the command prompt.
        /// </summary>
        /// <param name="args">Array of string from command prompt.</param>
        /// <param name="demo">Instance of class Demo to display info</param>
        private static void ShowArgs(string[] args, IDemo demo)
        {
            demo.Display(string.Format(
                Properties.Resources.ARGS,
                args.Length));
            for (int i = 0; i < args.Length; i++)
            {
                demo.Display(args[i]);
            }

            demo.Display(Properties.Resources.EMPTY_STRING);
        }
        
        /// <summary>
        /// Method to write or refresh information in test file.
        /// </summary>
        /// <param name="path">Customer path to the file.</param>
        /// <param name="demo">Instance of class Demo to display info</param>
        private static void RefreshFile(string path, IDemo demo)
        {
            string[] array =
            {
                "true  true      true   ",
                "false true false",
                "tr ue",
                "false",
                "true"
            };
            File.WriteAllLines(path, array);
            demo.Display(Properties.Resources.TEXT_FROM_FILE);
            demo.Display(string.Format(
                Properties.Resources.ONE_ARG, 
                File.ReadAllText(path)));
        }
    }
}
