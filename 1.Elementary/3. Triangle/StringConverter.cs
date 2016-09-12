using System;

namespace _3.Triangle
{
    static class StringConverter
    {
        public static double convertToDouble ( this string str )
        {
            double number;
            bool result = double.TryParse ( str, out number );
            if ( result == true )
            {
                return number;
            }
            throw new ArgumentException
                ( string.Format ( "Triangler parametr {0} can't be converted to double.", str ) );
        }
    }
}