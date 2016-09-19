﻿//-----------------------------------------------------------------------
// <copyright file="RussianNumberWriter.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number
{
    using Properties;

    /// <summary>
    /// Class to convert numbers to russian language.
    /// </summary>
    public class RussianNumberWriter : BaseNumberWriter
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="RussianNumberWriter" /> class.
        /// </summary>
        public RussianNumberWriter() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="RussianNumberWriter" /> class with one parameter.
        /// </summary>
        /// <param name="arg">Number as String 
        /// that is converted to words.</param>
        public RussianNumberWriter(string arg) : base(arg)
        {
        }

        /// <summary>
        /// Types of russian counting words.
        /// </summary>
        public enum Numbers
        {
            /// <summary>
            /// Represents zero.
            /// </summary>
            ноль,

            /// <summary>
            /// Represents one.
            /// </summary>
            один,

            /// <summary>
            /// Represents two.
            /// </summary>
            два,

            /// <summary>
            /// Represents three.
            /// </summary>
            три,

            /// <summary>
            /// Represents four.
            /// </summary>
            четыре,

            /// <summary>
            /// Represents five.
            /// </summary>
            пять,

            /// <summary>
            /// Represents six.
            /// </summary>
            шесть,

            /// <summary>
            /// Represents seven.
            /// </summary>
            семь,

            /// <summary>
            /// Represents eight.
            /// </summary>
            восемь,

            /// <summary>
            /// Represents nine.
            /// </summary>
            девять,

            /// <summary>
            /// Represents ten.
            /// </summary>
            десять,

            /// <summary>
            /// Represents eleven.
            /// </summary>
            одиннадцать,

            /// <summary>
            /// Represents twelve.
            /// </summary>
            двенадцать,

            /// <summary>
            /// Represents thirteen.
            /// </summary>
            тринадцать,

            /// <summary>
            /// Represents fourteen.
            /// </summary>
            четырнадцать,

            /// <summary>
            /// Represents fifteen.
            /// </summary>
            пятнадцать,

            /// <summary>
            /// Represents sixteen.
            /// </summary>
            шестнадцать,

            /// <summary>
            /// Represents seventeen.
            /// </summary>
            семнадцать,

            /// <summary>
            /// Represents eighteen.
            /// </summary>
            восемнадцать,

            /// <summary>
            /// Represents nineteen.
            /// </summary>
            девятнадцать,

            /// <summary>
            /// Represents twenty.
            /// </summary>
            двадцать,

            /// <summary>
            /// Represents thirty.
            /// </summary>
            тридцать = 30,

            /// <summary>
            /// Represents forty.
            /// </summary>
            сорoк = 40,

            /// <summary>
            /// Represents fifty.
            /// </summary>
            пятьдесят = 50,

            /// <summary>
            /// Represents sixty.
            /// </summary>
            шестьдесят = 60,

            /// <summary>
            /// Represents seventy.
            /// </summary>
            семьдесят = 70,

            /// <summary>
            /// Represents eighty.
            /// </summary>
            восемьдесят = 80,

            /// <summary>
            /// Represents ninety.
            /// </summary>
            девяносто = 90,

            /// <summary>
            /// Represents one hundred.
            /// </summary>
            сто = 100,

            /// <summary>
            /// Represents two hundred.
            /// </summary>
            двести = 200,

            /// <summary>
            /// Represents three hundred.
            /// </summary>
            триста = 300,

            /// <summary>
            /// Represents four hundred.
            /// </summary>
            четыреста = 400,

            /// <summary>
            /// Represents five hundred.
            /// </summary>
            пятьсот = 500,

            /// <summary>
            /// Represents six hundred.
            /// </summary>
            шестьсот = 600,

            /// <summary>
            /// Represents seven hundred.
            /// </summary>
            семьсот = 700,

            /// <summary>
            /// Represents eight hundred.
            /// </summary>
            восемьсот = 800,

            /// <summary>
            /// Represents nine hundred.
            /// </summary>
            девятьсот = 900
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
                    ((Numbers)this.Arg).ToString());
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
                int a1 = this.Arg - a2 - a3;

                if (a3 == 0 && a2 == 0)
                {
                    result = string.Format(
                        Resources.Display, 
                        ((Numbers)a1).ToString());
                }

                if (a3 == 0 && a2 != 0)
                {
                    result = string.Format(
                        Resources.DisplayTwo,
                        ((Numbers)a1).ToString(),
                        ((Numbers)a2).ToString());
                }

                if (a3 != 0 && a2 == 0)
                {
                    result = string.Format(
                        Resources.DisplayTwo,
                        ((Numbers)a1).ToString(),
                        ((Numbers)a3).ToString());
                }

                if (a3 != 0 && a2 != 0 && a1 != 0)
                {
                    result = string.Format(
                        Resources.DisplayThree,
                        ((Numbers)a1).ToString(),
                        ((Numbers)a2).ToString(),
                        ((Numbers)a3).ToString());
                }

                if (a22 < 21 && a22 != 0)
                {
                    result = string.Format(
                        Resources.DisplayTwo,
                        ((Numbers)a1).ToString(),
                        ((Numbers)a22).ToString());
                }

                if (a22 == 0)
                {
                    result = string.Format(
                        Resources.Display, 
                        ((Numbers)a1).ToString());
                }
            }

            return result;
        }
    }
}
