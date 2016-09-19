//-----------------------------------------------------------------------
// <copyright file="FileParser.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _4.FileParser.Parsers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using Demo;

    /// <summary>
    /// This class loads all data to the memory.
    /// </summary>
    public class FileParser : BaseParser
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="FileParser" /> class.
        /// </summary>
        public FileParser() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="FileParser" /> class.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        /// <param name="stringToFind">
        /// String for counting entrance to the file.
        /// </param>
        public FileParser(string pathToFile, string stringToFind)
            : base(pathToFile, stringToFind)
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="FileParser" /> class.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        /// <param name="stringToFind">String that will be changed.</param>
        /// <param name="stringToReplace">New string for swapping.</param>
        public FileParser(
            string pathToFile, string stringToFind, string stringToReplace)
            : base(pathToFile, stringToFind, stringToReplace)
        {
        }

        /// <summary>
        /// Method counts amount of entries of given strings 
        /// to the given file.
        /// </summary>
        /// <returns>
        /// Quantity of entries one given string to another given string.
        /// </returns>
        public override int Count()
        {
            string text = File.ReadAllText(PathToFile);
            return Regex.Matches(text, StringToFind).Count;            
        }

        /// <summary>
        /// Method replaces given strings in the given file.
        /// </summary>
        public override void Replace()
        {
            string text = File.ReadAllText(PathToFile);
            text = text.Replace(this.StringToFind, this.StringToReplace);
            File.WriteAllText(this.PathToFile, text);
        }
    }
}
