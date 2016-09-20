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
        /// Maximal value of number to covert to text.
        /// </summary>
        private int maxNumber = 999;

        /// <summary>
        /// Field of number that is converted to words.
        /// </summary>
        private int numberToText;

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
            this.NumberToText = int.Parse(arg);
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="BaseNumberWriter" /> class with one parameter.
        /// </summary>
        /// <param name="arg">Number as String 
        /// that is converted to words.</param>
        /// <param name="maxValue">Maximum value of number that 
        /// is to be converted to text.</param>
        public BaseNumberWriter(string arg, bool maxValue)
        {
            this.maxNumber = int.MaxValue;
            this.NumberToText = int.Parse(arg);
        }

        /// <summary>
        /// Gets or sets the maximum number that is converted to words.
        /// </summary>
        public int MaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the number that is converted to words.
        /// </summary>
        public int NumberToText
        {
            get
            {
                return this.numberToText;
            }

            set
            {
                if (Math.Abs(value) > this.maxNumber)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(Resources.NamberNotValid, value));
                }

                this.numberToText = value;
            }
        }

        /// <summary>
        /// Main method for converting number to words.
        /// </summary>
        /// <returns>Resulted string.</returns>
        public abstract string ConvertToText();
    }
}
