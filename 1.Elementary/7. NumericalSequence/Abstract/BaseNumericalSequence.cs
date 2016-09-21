//-----------------------------------------------------------------------
// <copyright file="BaseNumericalSequence.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _7.NumericalSequence.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using Demo;

    /// <summary>
    /// Abstract Class for getting needed sequence.
    /// </summary>
    public abstract class BaseNumericalSequence : INumericalSequence
    {
        /// <summary>
        /// Path to the specification file.
        /// </summary>
        private const string SPECIFICATION =
                @"..\..\TextFiles\specification.txt";

        /// <summary>
        /// Reference to collection interface of numbers.
        /// </summary>
        private ICollection<int> numbers;

        /// <summary>
        /// Reference to interface for displaying result.
        /// </summary>
        private IDemo demo;

        /// <summary>
        /// The low limit for numbers.
        /// </summary>
        private int lowLimit = 0;

        /// <summary>
        /// The upper limit for numbers.
        /// </summary>
        private int upperLimit;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BaseNumericalSequence" /> class.
        /// </summary>
        public BaseNumericalSequence()
        {
            this.demo = new ConsoleDemo();
            this.demo.Show(File.ReadAllText(SPECIFICATION));
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="BaseNumericalSequence" /> class with one parameter.
        /// </summary>
        /// <param name="upperLimit">The upper limit for numbers.</param>
        public BaseNumericalSequence(string upperLimit)
        {
            this.UpperLimit = int.Parse(upperLimit, CultureInfo.CurrentCulture);
            this.Numbers = new List<int>();
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="BaseNumericalSequence" /> class with two parameters.
        /// </summary>
        /// <param name="lowLimit">The low limit for numbers.</param>
        /// <param name="upperLimit">The upper limit for numbers.</param>
        public BaseNumericalSequence(string lowLimit, string upperLimit)
        {
            this.LowLimit = int.Parse(lowLimit, CultureInfo.CurrentCulture);
            this.UpperLimit = int.Parse(upperLimit, CultureInfo.CurrentCulture);
            this.Numbers = new List<int>();
        }

        /// <summary>
        /// Gets or sets collection of numbers.
        /// </summary>
        public ICollection<int> Numbers { get; set; }
        
        /// <summary>
        /// Gets or sets the low limit for numbers.
        /// </summary>
        public int LowLimit
        {
            get
            {
                return this.lowLimit;
            }

            set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                            Properties.Resources.LimitOut, value));
                }

                this.lowLimit = value;
            }
        }

        /// <summary>
        /// Gets or sets the upper limit for numbers.
        /// </summary>
        public int UpperLimit
        {
            get
            {
                return this.upperLimit;
            }

            set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                            Properties.Resources.LimitOut, value));
                }

                this.upperLimit = value;
            }
        }

        /// <summary>
        /// Calculating needed sequence.
        /// </summary>
        /// <returns>Collection of needed numbers</returns>
        public abstract ICollection<int> GetSequence();
    }
}
