//-----------------------------------------------------------------------
// <copyright file="BaseNumberWriter.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number
{
    using System;
    using Demo;
    using Properties;

    /// <summary>
    /// Abstract class for converting number to the word.
    /// </summary>
    public abstract class BaseNumberWriter : INumberWriter
    {
        /// <summary>
        /// Field of number that is converted to words.
        /// </summary>
        private int arg;

        /// <summary>
        /// Reference to interface for displaying result.
        /// </summary>
        private ConsoleDemo demo;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BaseNumberWriter" /> class that shows specification.
        /// </summary>
        public BaseNumberWriter()
        {
            this.demo = new ConsoleDemo();
            this.demo.ShowSpecification();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BaseNumberWriter" /> class with one parameter.
        /// </summary>
        /// <param name="arg">Number as String 
        /// that is converted to words.</param>
        public BaseNumberWriter(string arg)
        {
            int temp = this.ConvertToInt(arg);
            this.Arg = temp;
        }

        /// <summary>
        /// Gets or sets the number that is converted to words.
        /// </summary>
        public int Arg
        {
            get
            {
                return this.arg;
            }

            set
            {
                if (value < 0 || value > 999)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(Resources.NamberNotValid, value));
                }

                this.arg = value;
            }
        }

        /// <summary>
        /// Main method for converting number to words.
        /// </summary>
        /// <returns>Resulted string.</returns>
        public abstract string ConvertToText();

        /// <summary>
        /// Method trying to convert string to integer.
        /// </summary>
        /// <param name="arg">Number as String 
        /// that is converted to words.</param>
        /// <returns>Number to convert.</returns>
        private int ConvertToInt(string arg)
        {
            int number;
            bool result = int.TryParse(arg, out number);
            if (result)
            {
                return number;
            }

            throw new ArgumentException(string.Format(
                Resources.CannotConvert, number));
        }
    }
}
