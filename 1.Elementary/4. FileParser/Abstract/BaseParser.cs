//-----------------------------------------------------------------------
// <copyright file="BaseParser.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _4.FileParser
{
    using System;
    using System.IO;
    using System.Text;
    using _4.FileParser.Parsers;
    using Demo;

    /// <summary>
    /// This class parses files.
    /// </summary>
    public abstract class BaseParser : IParse
    {
        /// <summary>
        /// Path to the specification file.
        /// </summary>
        private const string SPECIFICATION = 
                @"..\..\TextFiles\Specification.txt";

        /// <summary>
        /// Path to the file for counting the string.
        /// </summary>
        private string pathToFile;

        /// <summary>
        /// String for finding.
        /// </summary>
        private string stringToFind;

        /// <summary>
        /// String for a replace.
        /// </summary>
        private string stringToReplace;
        
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="BaseParser" /> class.
        /// Constructor without parameters that represents the task.
        /// </summary>
        public BaseParser()
        {
                IDemo demo = new ConsoleDemo();
                demo.Display(File.ReadAllText(SPECIFICATION));
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="BaseParser" /> class.
        /// Constructor with two parameters that counts 
        /// given string in given file.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        /// <param name="stringToFind">
        /// String for counting entrance to the file.
        /// </param>
        public BaseParser(string pathToFile, string stringToFind)
        {
            this.PathToFile = pathToFile;
            this.StringToFind = stringToFind;
        }
        
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="BaseParser" /> class.
        /// Constructor with three parameters that 
        /// swaps given strings in given file.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        /// <param name="stringToFind">String that will be changed.</param>
        /// <param name="stringToReplace">New string for swapping.</param>
        public BaseParser(
            string pathToFile, string stringToFind, string stringToReplace)
        {
            this.PathToFile = pathToFile;
            this.StringToFind = stringToFind;
            this.StringToReplace = stringToReplace;
        }

        /// <summary>
        /// Gets or sets the field of path to the file for parsing.
        /// </summary>
        public string PathToFile
        {
            get
            {
                return this.pathToFile;
            }

            set
            {
                if (!File.Exists(value))
                {
                    throw new ArgumentNullException(string.Format(
                        Properties.Resources.FILE_NOT_EXISTS, value));
                }

                this.pathToFile = value;
            }
        }

        /// <summary>
        /// Gets or sets the field string for finding.
        /// </summary>
        public string StringToFind
        {
            get
            {
                return this.stringToFind;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        Properties.Resources.STRING_NULL_EMPTY, value);
                }

                this.stringToFind = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the field of string for a swap.
        /// </summary>
        public string StringToReplace
        {
            get
            {
                return this.stringToReplace;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        Properties.Resources.STRING_NULL, value);
                }

                this.stringToReplace = value;
            }
        }

        /// <summary>
        /// Abstract method to count string.
        /// </summary>
        /// <returns>
        /// Quantity of entries one given string to another given string.
        /// </returns>
        public abstract int Count();

        /// <summary>
        /// Abstract method to replace strings.
        /// </summary>
        public abstract void Replace();                
    }
}