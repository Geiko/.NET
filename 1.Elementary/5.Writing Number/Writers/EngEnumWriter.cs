//-----------------------------------------------------------------------
// <copyright file="EngEnumWriter.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number
{
    using System;
    using Properties;

    /// <summary>
    /// Class to convert numbers to english language.
    /// </summary>
    public class EngEnumWriter : BaseNumberWriter
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EngEnumWriter" /> 
        /// class that shows specification.
        /// </summary>
        public EngEnumWriter() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EngEnumWriter" /> class with one parameter.
        /// </summary>
        /// <param name="arg">Number as String 
        /// that is converted to words.</param>
        public EngEnumWriter(string arg) : base(arg)
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
            hundred = 100
        }

        /// <summary>
        /// Main method for converting number to words.
        /// </summary>
        /// <returns>Resulted string</returns>
        public override string ConvertToText()
        {
            bool minus = this.NumberToText < 0 ? true : false;
            this.NumberToText = Math.Abs(this.NumberToText);
            string result = string.Empty;
            if (this.NumberToText <= 20)
            {
                result = string.Format(
                    Resources.Display,
                    ((Numbers)this.NumberToText).ToString());
            }
            else if (this.NumberToText > 20 && this.NumberToText < 100)
            {
                result = this.GetResultFor21To99();
            }
            else if (this.NumberToText >= 100)
            {
                result = this.GetResultForMore99();
            }

            if (minus)
            {
                result = string.Format(
                        Resources.DisplayTwo,
                        ((Numbers)(-1)).ToString(),
                        result);
            }

            return result;
        }

        /// <summary>
        /// Definition a string for a range 21 - 99.
        /// </summary>
        /// <returns>Resulted string.</returns>
        private string GetResultFor21To99()
        {
            int a2 = this.NumberToText % 10;
            int a1 = this.NumberToText - a2;

            if (a2 == 0)
            {
                return string.Format(
                    Resources.Display,
                    ((Numbers)a1).ToString());
            }
            else
            {
                return string.Format(
                    Resources.DisplayTwo,
                    ((Numbers)a1).ToString(),
                    ((Numbers)a2).ToString());
            }
        }

        /// <summary>
        /// Definition a string for a number > 99.
        /// </summary>
        /// <returns>Resulted string.</returns>
        private string GetResultForMore99()
        {
            int a3 = this.NumberToText % 10;
            int a2 = (this.NumberToText - a3) % 100;
            int a22 = this.NumberToText % 100;
            int a1 = (this.NumberToText - a2 - a3) / 100;

            if (a3 == 0 && a2 == 0)
            {
                return string.Format(
                    Resources.DisplayTwo,
                    ((Numbers)a1).ToString(),
                    (Numbers)100);
            }
            else if (a3 == 0 && a2 != 0)
            {
                return string.Format(
                    Resources.DisplayThree,
                    ((Numbers)a1).ToString(),
                    ((Numbers)100).ToString(),
                    ((Numbers)a2).ToString());
            }
            else if (a3 != 0 && a2 == 0)
            {
                return string.Format(
                    Resources.DisplayThree,
                    ((Numbers)a1).ToString(),
                    ((Numbers)100).ToString(),
                    ((Numbers)a3).ToString());
            }
            else if (a3 != 0 && a2 != 0 && a1 != 0)
            {
                return string.Format(
                    Resources.DisplayFour,
                    ((Numbers)a1).ToString(),
                    ((Numbers)100).ToString(),
                    ((Numbers)a2).ToString(),
                    ((Numbers)a3).ToString());
            }
            else if (a22 < 21 && a22 != 0)
            {
                return string.Format(
                    Resources.DisplayThree,
                    ((Numbers)a1).ToString(),
                    ((Numbers)100).ToString(),
                    ((Numbers)a22).ToString());
            }
            else if (a22 == 0)
            {
                return string.Format(
                    Resources.DisplayTwo,
                    ((Numbers)a1).ToString(),
                    (Numbers)100).ToString();
            }

            return null;
        }
    }
}
