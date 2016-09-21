//-----------------------------------------------------------------------
// <copyright file="StreamParser.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _4.FileParser.Parsers
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using Demo;

    /// <summary>
    /// If the file is very big we have to read it by one row 
    /// in order not to load all data to the memory.
    /// This class enable it with streams.
    /// </summary>
    public class StreamParser : BaseParser
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="StreamParser" /> class.
        /// </summary>
        public StreamParser() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="StreamParser" /> class.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        /// <param name="stringToFind">
        /// String for counting entrance to the file.
        /// </param>
        public StreamParser(string pathToFile, string stringToFind)
            : base(pathToFile, stringToFind)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="StreamParser" /> class.
        /// </summary>
        /// <param name="pathToFile">
        /// Path to the file for counting the string.
        /// </param>
        /// <param name="stringToFind">String that will be changed.</param>
        /// <param name="stringToReplace">New string for swapping.</param>
        public StreamParser(
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
            int entries = 0;
            using (System.IO.StreamReader reader =
                    new System.IO.StreamReader(PathToFile, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains(this.StringToFind))
                    {
                        entries += Regex.Matches(line, StringToFind).Count;
                    }
                }
            }

            return entries;
        }
        
        /// <summary>
        /// Method Swaps strings in the given file.
        /// </summary>
        public override void Replace()
        {
            const string TEMP_FILE = "temp.txt";
            using (StreamReader reader =
                    new StreamReader(PathToFile, Encoding.UTF8))
            {
                using (StreamWriter writer = new StreamWriter(TEMP_FILE))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.Contains(this.StringToFind))
                        {
                            line = line.Replace(
                                this.StringToFind, this.StringToReplace);
                        }

                        writer.WriteLine(line);
                    }
                }
            }

            using (StreamReader reader =
                    new StreamReader(TEMP_FILE, Encoding.UTF8))
            {
                using (StreamWriter writer = new StreamWriter(PathToFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine(line);
                    }
                }
            }
            
            File.Delete(TEMP_FILE);
        }
    }
}
