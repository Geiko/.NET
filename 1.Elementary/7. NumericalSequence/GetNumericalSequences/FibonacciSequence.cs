//-----------------------------------------------------------------------
// <copyright file="FibonacciSequence.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _7.NumericalSequence.GetNumericalSequences
{
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;

    /// <summary>
    /// Class for getting natural sequence with given upper limit.
    /// </summary>
    public class FibonacciSequence : BaseNumericalSequence
    {
        /// <summary>
        ///  Initializes a new instance of the 
        ///  <see cref="FibonacciSequence" /> class.
        /// </summary>
        public FibonacciSequence() 
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="FibonacciSequence" /> class with one parameter.
        /// </summary>
        /// <param name="lowLimit">Low limit for numbers.</param>
        /// <param name="upperLimit">Upper limit for numbers.</param>
        public FibonacciSequence(string lowLimit, string upperLimit) 
            : base(lowLimit, upperLimit)
        {
        }

        /// <summary>
        /// Calculating natural sequence.
        /// </summary>
        /// <returns>Natural sequence.</returns>
        public override ICollection<int> GetSequence()
        {
            int a = 0;
            long b = 1;
            while (true)
            {
                int temp = a;
                a = (int)b;
                b = temp + b;
                if (b > int.MaxValue) 
                {
                    break;
                }

                if (a > this.UpperLimit)
                {
                    break;
                }

                if (a > this.LowLimit)
                {
                    this.Numbers.Add(a);
                }
            }

            return this.Numbers;
        }
    }
}
