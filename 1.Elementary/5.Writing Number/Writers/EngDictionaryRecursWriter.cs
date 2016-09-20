//-----------------------------------------------------------------------
// <copyright file="EngDictionaryRecursWriter.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _5.Writing_Number.Writers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Properties;

    /// <summary>
    /// Class to convert numbers to english language with recursion.
    /// </summary>
    public class EngDictionaryRecursWriter : BaseNumberWriter
    {
        /// <summary>
        /// Numerated collection of words.
        /// </summary>
        private IDictionary<int, string> englDictionary;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EngDictionaryRecursWriter" /> 
        /// class that shows specification.
        /// </summary>
        public EngDictionaryRecursWriter() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EngDictionaryRecursWriter" /> class with one parameter.
        /// </summary>
        /// <param name="arg">Number as String 
        /// that is converted to words.</param>
        /// <param name="maxValue">Maximum value of number that 
        /// is to be converted to text.</param>
        public EngDictionaryRecursWriter(string arg, bool maxValue)
            : base(arg, maxValue)
        {
            this.englDictionary = new Dictionary<int, string>();
            this.InitializationDictionary();
        }

        /// <summary>
        /// Main method for converting number to words.
        /// </summary>
        /// <returns>Resulted string</returns>
        public override string ConvertToText()
        {
            this.MaxNumber = int.MaxValue;
            return this.NumberToWords(this.NumberToConvert);
        }

        /// <summary>
        /// It makes an initialization of the dictionary.
        /// </summary>
        private void InitializationDictionary()
        {
            this.englDictionary.Add(0, Resources.zero);
            this.englDictionary.Add(1, Resources.one);
            this.englDictionary.Add(2, Resources.two);
            this.englDictionary.Add(3, Resources.three);
            this.englDictionary.Add(4, Resources.four);
            this.englDictionary.Add(5, Resources.five);
            this.englDictionary.Add(6, Resources.six);
            this.englDictionary.Add(7, Resources.seven);
            this.englDictionary.Add(8, Resources.eight);
            this.englDictionary.Add(9, Resources.nine);
            this.englDictionary.Add(10, Resources.ten);
            this.englDictionary.Add(11, Resources.eleven);
            this.englDictionary.Add(12, Resources.twelve);
            this.englDictionary.Add(13, Resources.thirteen);
            this.englDictionary.Add(14, Resources.fourteen);
            this.englDictionary.Add(15, Resources.fifteen);
            this.englDictionary.Add(16, Resources.sixteen);
            this.englDictionary.Add(17, Resources.seventeen);
            this.englDictionary.Add(18, Resources.eighteen);
            this.englDictionary.Add(19, Resources.nineteen);
            this.englDictionary.Add(20, Resources.twenty);
            this.englDictionary.Add(30, Resources.thirty);
            this.englDictionary.Add(40, Resources.forty);
            this.englDictionary.Add(50, Resources.fifty);
            this.englDictionary.Add(60, Resources.sixty);
            this.englDictionary.Add(70, Resources.seventy);
            this.englDictionary.Add(80, Resources.eighty);
            this.englDictionary.Add(90, Resources.ninety);
            this.englDictionary.Add(100, Resources.hundred);
            this.englDictionary.Add(1000, Resources.thousand);
            this.englDictionary.Add(1000000, Resources.million);
            this.englDictionary.Add(1000000000, Resources.milliard);
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
                return this.englDictionary[0];
            }

            StringBuilder builder = new StringBuilder();
            if (number < 0)
            {
                builder.Append(Resources.minus);
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
                builder.Append(this.englDictionary[1000000000]);
                builder.Append(Resources.Blank);
                words = builder.ToString();
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                builder.Append(this.NumberToWords(number / 1000000));
                builder.Append(Resources.Blank);
                builder.Append(this.englDictionary[1000000]);
                builder.Append(Resources.Blank);
                words = builder.ToString();
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                builder.Append(this.NumberToWords(number / 1000));
                builder.Append(Resources.Blank);
                builder.Append(this.englDictionary[1000]);
                builder.Append(Resources.Blank);
                words = builder.ToString();
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                builder.Append(this.NumberToWords(number / 100));
                builder.Append(Resources.Blank);
                builder.Append(this.englDictionary[100]);
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
                            this.englDictionary[number]);
                }
                else
                {
                    words = string.Format(
                            Resources.DisplayTwo,
                            words,
                            this.englDictionary[number - (number % 10)]);
                    if ((number % 10) > 0)
                    {
                        words = string.Format(
                            Resources.DisplayThree,
                            words,
                            Resources.Hyphen,
                            this.englDictionary[number % 10]);
                    }
                }
            }

            return words;
        }
    }
}
