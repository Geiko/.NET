//-----------------------------------------------------------------------
// <copyright file="NaturalSequence.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _7.NumericalSequence.GetNumericalSequences
{
    using System.Collections.Generic;
    using Abstract;
    using Properties;

    /// <summary>
    /// Class for getting natural sequence with given upper limit.
    /// </summary>
    public class NaturalSequence : BaseNumericalSequence
    {
        /// <summary>
        ///  Initializes a new instance of the 
        ///  <see cref="NaturalSequence" /> class.
        /// </summary>
        public NaturalSequence() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="NaturalSequence" /> class with one parameter.
        /// </summary>
        /// <param name="upperLimit">Upper limit for numbers.</param>
        public NaturalSequence(string upperLimit) : base(upperLimit)
        {
        }

        /// <summary>
        /// Calculating natural sequence.
        /// List will be limited to the max of an array, which is 2GB.
        /// Since no single object in a .Net program may be over 2GB 
        /// and the string type uses unicode 
        /// (2 bytes for each character), 
        /// the best you could do is 1,073,741,823, 
        /// but you're not likely to ever be able to allocate 
        /// that on a 32-bit machine.
        /// </summary>
        /// <returns>Natural sequence.</returns>
        public override ICollection<int> GetSequence()
        {
            int i = 0;
            while (true)
            {
                i++;
                if (i * i > this.UpperLimit)
                {
                    break;
                }
                
                this.Numbers.Add(i);
            }
           
            return this.Numbers;
        }
    }
}
