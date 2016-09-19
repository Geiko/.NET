//-----------------------------------------------------------------------
// <copyright file="Triangle.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _3.Triangle.Entities
{
    using System;
    using Properties;

    /// <summary>
    /// It is a structure of triangle.
    /// </summary>
    public struct Triangle : IComparable<Triangle>
    {
        /// <summary>
        /// It is a field for name of triangle.
        /// </summary>
        private string name;

        /// <summary>
        /// It is a field for length of a triangle side.
        /// </summary>
        private double a;

        /// <summary>
        /// It is a field for length of a triangle side.
        /// </summary>
        private double b;

        /// <summary>
        /// It is a field for length of a triangle side.
        /// </summary>
        private double c;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle" /> struct.
        /// </summary>
        /// <param name="name">Name of a triangle.</param>
        /// <param name="a">First length of a triangle side.</param>
        /// <param name="b">Second length of a triangle side.</param>
        /// <param name="c">Third length of a triangle side.</param>
        public Triangle(string name, double a, double b, double c) : this()
        {
            if (c <= Math.Abs(a - b) || c >= a + b)
            {
                throw new ArgumentOutOfRangeException(
                        string.Format(Resources.NoTriangle));
            }

            this.Name = name;
            this.A = a;
            this.B = b;
            this.C = c;
        }

        /// <summary>
        /// Gets or sets and validate name of triangle.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) == true)
                {
                    throw new ArgumentOutOfRangeException(
                            string.Format(Resources.NoName, value));
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets and validate length of triangle side.
        /// </summary>
        public double A
        {
            get
            {
                return this.a;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                            string.Format(Resources.NoSide, value));
                }

                this.a = value;
            }
        }

        /// <summary>
        /// Gets or sets and validate length of triangle side.
        /// </summary>
        public double B
        {
            get
            {
                return this.b;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                            string.Format(Resources.NoSide, value));
                }

                this.b = value;
            }
        }

        /// <summary>
        /// Gets or sets and validate length of triangle side.
        /// </summary>
        public double C
        {
            get
            {
                return this.c;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                          string.Format(Resources.NoSide, value));
                }

                this.c = value;
            }
        }

        /// <summary>
        /// Gerona formula is used to calculate a triangle area.
        /// </summary>
        /// <returns>Area of triangle.</returns>
        public double GetArea()
        {
            double p = (this.a + this.b + this.c) / 2;
            return Math.Sqrt(p * (p - this.a) * (p - this.b) * (p - this.c));
        }

        /// <summary>
        /// Reset ToString() for triangle.
        /// </summary>
        /// <returns>String with description of triangle.</returns>
        public override string ToString()
        {
            return string.Format(
                Resources.Triangle,
                this.name,
                this.GetArea(),
                this.a,
                this.b,
                this.c);
        }

        /// <summary>
        /// Set way to compare two triangles.
        /// </summary>
        /// <param name="otherTriangle">Object of other triangle.</param>
        /// <returns>More, less, or equal</returns>
        public int CompareTo(Triangle otherTriangle)
        {
            if (this.GetArea() > otherTriangle.GetArea())
            {
                return -1;
            }
            else if (otherTriangle.GetArea() > this.GetArea())
            {
                return 1;
            }

            return 0;
        }
    }
}
