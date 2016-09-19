//-----------------------------------------------------------------------
// <copyright file="EnglishNumberWriter.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number
{
    using Properties;

    /// <summary>
    /// Class to convert numbers to english language.
    /// </summary>
    public class EnglishNumberWriter : BaseNumberWriter
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EnglishNumberWriter" /> 
        /// class that shows specification.
        /// </summary>
        public EnglishNumberWriter() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EnglishNumberWriter" /> class with one parameter.
        /// </summary>
        /// <param name="arg">Number as String 
        /// that is converted to words.</param>
        public EnglishNumberWriter(string arg) : base(arg)
        {
        }

        /// <summary>
        /// Enumeration of english counting words
        /// </summary>
        public enum Numbers
        {
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
            string result = string.Empty;
            if (this.Arg <= 20)
            {
                result = string.Format(
                    Resources.Display, 
                    ((Numbers)Arg).ToString());
            }
            else if (this.Arg > 20 && this.Arg < 100)
            {
                int a2 = this.Arg % 10;
                int a1 = this.Arg - a2;

                if (a2 == 0)
                {
                    result = string.Format(
                        Resources.Display, 
                        ((Numbers)a1).ToString());
                }
                else
                {
                    result = string.Format(
                        Resources.DisplayTwo,
                        ((Numbers)a1).ToString(),
                        ((Numbers)a2).ToString());
                }
            }
            else if (this.Arg >= 100)
            {
                int a3 = this.Arg % 10;
                int a2 = (this.Arg - a3) % 100;
                int a22 = this.Arg % 100;
                int a1 = (this.Arg - a2 - a3) / 100;

                if (a3 == 0 && a2 == 0)
                {
                    result = string.Format(
                        Resources.DisplayTwo, 
                        ((Numbers)a1).ToString(), 
                        (Numbers)100);
                }

                if (a3 == 0 && a2 != 0)
                {
                    result = string.Format(
                        Resources.DisplayThree,
                        ((Numbers)a1).ToString(), 
                        ((Numbers)100).ToString(), 
                        ((Numbers)a2).ToString());
                }

                if (a3 != 0 && a2 == 0)
                {
                    result = string.Format(
                        Resources.DisplayThree,
                        ((Numbers)a1).ToString(), 
                        ((Numbers)100).ToString(),
                        ((Numbers)a3).ToString());
                }

                if (a3 != 0 && a2 != 0 && a1 != 0)
                {
                    result = string.Format(
                        Resources.DisplayFour,
                        ((Numbers)a1).ToString(),
                        ((Numbers)100).ToString(),
                        ((Numbers)a2).ToString(),
                        ((Numbers)a3).ToString());
                }

                if (a22 < 21 && a22 != 0)
                {
                    result = string.Format(
                        Resources.DisplayThree,
                        ((Numbers)a1).ToString(),
                        ((Numbers)100).ToString(),
                        ((Numbers)a22).ToString());
                }

                if (a22 == 0)
                {
                    result = string.Format(
                        Resources.DisplayTwo,
                        ((Numbers)a1).ToString(),
                        (Numbers)100).ToString();
                }
            }

            return result;
        }
    }
}
