//-----------------------------------------------------------------------
// <copyright file="StringConvertor.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _7.NumericalSequence.Abstract
{
    using System;
    using Demo;
    using Properties;

    /// <summary>
    /// Static class for extension method.
    /// </summary>
    public static class StringConvertor
    {
        /// <summary>
        /// Extension method to convert string argument to long limit.
        /// </summary>
        /// <param name="str">Limit number as string</param>
        /// <returns>Limit number as long.</returns>
        public static int ConvertToInt(this string str)
        {
            int number;
            bool result = int.TryParse(str, out number);
            if (result)
            {
                return number;
            }

            IDemo demo = new ConsoleDemo();
            demo.Show(Resources.ArgWrong);
            throw new ArgumentException();
        }
    }
}