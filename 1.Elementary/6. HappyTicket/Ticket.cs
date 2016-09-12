using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.HappyTicket
{
    struct Ticket
    {
        private string number;



        public string Number
        {
            get { return number; }
            set
            {
                if ( value.Length < 2 )
                {
                    throw new ArgumentOutOfRangeException ( string.Format ( "Number {0} is less then 2", value ) );
                }
                //int any;
                //if ( int.TryParse ( value, out any ) == false )

                //if(Regex.IsMatch(value, @"^\d+$" ) == false )

                if ( value.All ( char.IsDigit ) == false )
                {
                    throw new ArgumentException ( string.Format ( "Number {0} contains not only digits", value ) );
                }
                number = value;
            }
        }



        public Ticket ( string str ) : this ( )
        {
            try
            {
                Number = str;
            }
            catch ( ArgumentException ex )
            {
                Console.WriteLine ( ex.Message );
            }
        }



    }
}
