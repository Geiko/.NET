//-----------------------------------------------------------------------
// <copyright file="Envelope.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _2.Envelope.Entities
{
    using System;
    using Properties;

    /// <summary>
    /// It is structure of an envelope.
    /// </summary>
    public struct Envelope : IComparable<Envelope>
    {
        /// <summary>
        /// It is a field for longer side of an envelope.
        /// </summary>
        private double longSide;

        /// <summary>
        /// It is a field for shorter side of an envelope.
        /// </summary>
        private double shortSide;

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope" /> struct.
        /// </summary>
        /// <param name="a">One side of an envelope.</param>
        /// <param name="b"> Another side of an envelope.</param>
        public Envelope(double a, double b) : this()
        {
            if (a <= b)
            {
                this.ShortSide = a;
                this.LongSide = b;
            }
            else
            {
                this.ShortSide = b;
                this.LongSide = a;
            }
        }

        /// <summary>
        /// Gets or sets long side of an envelope.
        /// </summary>
        public double LongSide
        {
            get
            {
                return this.longSide;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(Resources.NoLongSize, value.ToString()));
                }

                this.longSide = value;
            }
        }

        /// <summary>
        /// Gets or sets short side of an envelope.
        /// </summary>
        public double ShortSide
        {
            get
            {
                return this.shortSide;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                       string.Format(Resources.NoShortSide, value.ToString()));
                }

                this.shortSide = value;
            }
        }

        /// <summary>
        /// Method to compare two envelops.
        /// </summary>
        /// <param name="other">Another object of Envelope to compare.</param>
        /// <returns>Integer to define compare.</returns>
        public int CompareTo(Envelope other)
        {
            if (this.LongSide < other.LongSide && 
                this.ShortSide < other.ShortSide)
            {
                return -1;
            }
            else if (this.LongSide > other.LongSide && 
                this.ShortSide > other.ShortSide)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Reset ToString() for an envelope.
        /// </summary>
        /// <returns>Envelope as string.</returns>
        public override string ToString()
        {
            return string.Format(
                Resources.EnvelopeSize, this.shortSide, this.longSide);
        }
    }
}
