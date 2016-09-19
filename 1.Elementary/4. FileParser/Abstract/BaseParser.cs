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
        /// Initializes a new instance of the 
        /// <see cref="BaseParser" /> class.
        /// Constructor without parameters that represents the task.
        /// </summary>
        public BaseParser()
        {
                string message = Properties.Resources.SPEC_FILE;
                IDemo demo = new ConsoleDemo();
                demo.Display(message);
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
            this.Validate(pathToFile, stringToFind);
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
            this.Validate(pathToFile, stringToFind, stringToReplace);
            this.PathToFile = pathToFile;
            this.StringToFind = stringToFind;
            this.StringToReplace = stringToReplace;
        }

        /// <summary>
        /// Gets or sets the field of path to the file for parsing.
        /// </summary>
        public string PathToFile { get; set; }

        /// <summary>
        /// Gets or sets the field string for finding.
        /// </summary>
        public string StringToFind { get; set; }

        /// <summary>
        /// Gets or sets the field of string for a swap.
        /// </summary>
        public string StringToReplace { get; set; }

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

        /// <summary>
        /// It is validate two parameters.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        /// <param name="stringToFind">
        /// String for counting entrance to the file.
        /// </param>
        private void Validate(string pathToFile, string stringToFind)
        {
            this.ValidatePathToFile(pathToFile);
            this.ValidateString(stringToFind);
        }

        /// <summary>
        /// It is validate three parameters.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        /// <param name="stringToFind">String that will be changed.</param>
        /// <param name="stringToReplace">New string for swapping.</param>
        private void Validate(
                string pathToFile, 
                string stringToFind, 
                string stringToReplace)
        {
            this.ValidatePathToFile(pathToFile);
            this.ValidateString(stringToFind);
            this.ValidateString(stringToReplace);
        }

        /// <summary>
        /// It is validate the path to the file.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        private void ValidatePathToFile(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException(string.Format(
                    Properties.Resources.FILE_NOT_EXISTS, 
                    pathToFile));
            }
        }

        /// <summary>
        /// It is validate a string.
        /// </summary>
        /// <param name="stringToFind">
        /// String for counting entrance to the file.
        /// </param>
        private void ValidateString(string stringToFind)
        {
            if (stringToFind == null)
            {
                throw new ArgumentNullException(string.Format(
                    Properties.Resources.STRING_NULL, stringToFind));
            }
        }
    }
}