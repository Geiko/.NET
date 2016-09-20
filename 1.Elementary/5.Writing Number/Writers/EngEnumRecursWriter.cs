//-----------------------------------------------------------------------
// <copyright file="EngEnumRecursWriter.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number.Writers
{
    using System;
    using System.Text;
    using Properties;

    /// <summary>
    /// Class to convert numbers to english language with recursion.
    /// </summary>
    public class EngEnumRecursWriter : BaseNumberWriter
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EngEnumRecursWriter" /> 
        /// class that shows specification.
        /// </summary>
        public EngEnumRecursWriter() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EngEnumRecursWriter" /> class with one parameter.
        /// </summary>
        /// <param name="arg">Number as String 
        /// that is converted to words.</param>
        /// <param name="maxValue">Maximum value of number that 
        /// is to be converted to text.</param>
        public EngEnumRecursWriter(string arg, bool maxValue)
            : base(arg, maxValue)
        {
        }

        /// <summary>
        /// Enumeration of english counting words
        /// </summary>
        public enum Numbers
        {
            /// <summary>
            /// Represents minus.
            /// </summary>
            minus = -1,

            /// <summary>
            /// Represents zero.
            /// </summary>
            zero,

            /// <summary>
            /// Represents one.
            /// </summary>
            one,

            /// <summary>
            /// Represents two.
            /// </summary>
            two,

            /// <summary>
            /// Represents three.
            /// </summary>
            three,

            /// <summary>
            /// Represents four.
            /// </summary>
            four,

            /// <summary>
            /// Represents five.
            /// </summary>
            five,

            /// <summary>
            /// Represents six.
            /// </summary>
            six,

            /// <summary>
            /// Represents seven.
            /// </summary>
            seven,

            /// <summary>
            /// Represents eight.
            /// </summary>
            eight,

            /// <summary>
            /// Represents nine.
            /// </summary>
            nine,

            /// <summary>
            /// Represents ten.
            /// </summary>
            ten,

            /// <summary>
            /// Represents eleven.
            /// </summary>
            eleven,

            /// <summary>
            /// Represents twelve.
            /// </summary>
            twelve,

            /// <summary>
            /// Represents thirteen.
            /// </summary>
            thirteen,

            /// <summary>
            /// Represents fourteen.
            /// </summary>
            fourteen,

            /// <summary>
            /// Represents fifteen.
            /// </summary>
            fifteen,

            /// <summary>
            /// Represents sixteen.
            /// </summary>
            sixteen,

            /// <summary>
            /// Represents seventeen.
            /// </summary>
            seventeen,

            /// <summary>
            /// Represents eighteen.
            /// </summary>
            eighteen,

            /// <summary>
            /// Represents nineteen.
            /// </summary>
            nineteen,

            /// <summary>
            /// Represents twenty.
            /// </summary>
            twenty,

            /// <summary>
            /// Represents thirty.
            /// </summary>
            thirty = 30,

            /// <summary>
            /// Represents forty.
            /// </summary>
            forty = 40,

            /// <summary>
            /// Represents fifty.
            /// </summary>
            fifty = 50,

            /// <summary>
            /// Represents sixty.
            /// </summary>
            sixty = 60,

            /// <summary>
            /// Represents seventy.
            /// </summary>
            seventy = 70,

            /// <summary>
            /// Represents eighty.
            /// </summary>
            eighty = 80,

            /// <summary>
            /// Represents ninety.
            /// </summary>
            ninety = 90,

            /// <summary>
            /// Represents hundred.
            /// </summary>
            hundred = 100,

            /// <summary>
            /// Represents thousand.
            /// </summary>
            thousand = 1000,

            /// <summary>
            /// Represents million.
            /// </summary>
            million = 1000000,

            /// <summary>
            /// Represents milliard.
            /// </summary>
            milliard = 1000000000
        }

        /// <summary>
        /// Main method for converting number to words.
        /// </summary>
        /// <returns>Resulted string</returns>
        public override string ConvertToText()
        {
            this.MaxNumber = int.MaxValue;
            return this.NumberToWords(this.NumberToText);
        }

        /// <summary>
        /// Recursion method to convert number to text.
        /// </summary>
        /// <param name="number">Number to be converted to text.</param>
        /// <returns>Converted text.</returns>
        private string NumberToWords(int number)
        {
            if (number == 0)
            {
                return ((Numbers)0).ToString();
            }

            StringBuilder builder = new StringBuilder();
            if (number < 0)
            {
                builder.Append(((Numbers)(-1)).ToString());
                builder.Append(Resources.Blank);
                builder.Append(this.NumberToWords(Math.Abs(number)));
                return builder.ToString();
            }

            string words = string.Empty;

            if ((number / 1000000000) > 0)
            {
                builder.Append(words);
                builder.Append(this.NumberToWords(number / 1000000000));
                builder.Append(Resources.Blank);
                builder.Append(((Numbers)1000000000).ToString());
                builder.Append(Resources.Blank);
                words = builder.ToString();
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                builder.Append(this.NumberToWords(number / 1000000));
                builder.Append(Resources.Blank);
                builder.Append(((Numbers)1000000).ToString());
                builder.Append(Resources.Blank);
                words = builder.ToString();
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                builder.Append(this.NumberToWords(number / 1000));
                builder.Append(Resources.Blank);
                builder.Append(((Numbers)1000).ToString());
                builder.Append(Resources.Blank);
                words = builder.ToString();
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                builder.Append(this.NumberToWords(number / 100));
                builder.Append(Resources.Blank);
                builder.Append(((Numbers)100).ToString());
                builder.Append(Resources.Blank);
                words = builder.ToString();
                number %= 100;
            }

            if (number > 0)
            {
                if (words != string.Empty)
                {
                    words = string.Format(
                            Resources.DisplayTwo,
                            words,
                            Resources.And);
                }

                if (number < 20)
                {
                    words = string.Format(
                            Resources.DisplayTwo,
                            words,
                            ((Numbers)number).ToString());
                }
                else
                {
                    words = string.Format(
                            Resources.DisplayTwo,
                            words,
                            ((Numbers)(number - (number % 10))).ToString());
                    if ((number % 10) > 0)
                    {
                        words = string.Format(
                            Resources.DisplayThree,
                            words,
                            Resources.Hyphen,
                            ((Numbers)(number % 10)).ToString());
                    }
                }
            }

            return words;
        }
    }
}
