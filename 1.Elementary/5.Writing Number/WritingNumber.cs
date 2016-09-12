using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Writing_Number
{
    class WritingNumber
    {
        private int x;

        public int X
        {
            get { return x; }
            set
            {
                if ( value < 0 || value > 999 )
                {
                    throw new ArgumentOutOfRangeException ( string.Format ( "Number {0} out of range 0-999", value ) );
                }
                x = value;
            }
        }



        enum Numbers
        {
            ноль, один, два, три, четыре, пять, шесть, семь, восемь, девять,

            десять, одиннадцать, двенадцать, тринадцать, четырнадцать, пятнадцать,
                    шестнадцать, семнадцать, восемнадцать, девятнадцать,

            двадцать,
            тридцать = 30,
            сорoк = 40,
            пятьдесят = 50,
            шестьдесят = 60,
            семьдесят = 70,
            восемьдесят = 80,
            девяносто = 90,

            сто = 100, двести = 200, триста = 300, четыреста = 400, пятьсот = 500,
                 шестьсот = 600, семьсот = 700, восемьсот = 800, девятьсот = 900
        }



        public WritingNumber ( )
        {
            Console.WriteLine ( File.ReadAllText ( "task.txt" ) );
        }



        public WritingNumber ( int x )
        {
            try
            {
                X = x;

                if ( X <= 20 )
                {
                    Console.WriteLine ( "{0} - {1}", X, ( Numbers ) X );
                }
                else if ( X > 20 && X < 100 )
                {
                    int a2 =  X % 10;
                    int a1 =  X - a2;

                    if ( a2 == 0  )
                    {
                        Console.WriteLine ( "{0} - {1}", X, ( Numbers ) a1 );
                    }
                    else
                    {
                        Console.WriteLine ( "{0} - {1} {2}", X, ( Numbers ) a1, ( Numbers ) a2 );
                    }
                }
                else if ( X > 100 )
                {
                    int a3 = X % 10;
                    int a2 = (X - a3) % 100;
                    int a1 = X - a2 - a3;

                    if ( a3 == 0 && a2 == 0 )
                    {
                        Console.WriteLine ( "{0} - {1}", X, ( Numbers ) a1 );
                    }
                    if ( a3 == 0 && a2 != 0 )
                    {
                        Console.WriteLine ( "{0} - {1} {2}", X, ( Numbers ) a1, ( Numbers ) a2 );
                    }
                    if ( a3 != 0 && a2 == 0 )
                    {
                        Console.WriteLine ( "{0} - {1} {2}", X, ( Numbers ) a1, ( Numbers ) a3 );
                    }
                    if ( a3 != 0 && a2 != 0 && a1 != 0 )
                    {
                        Console.WriteLine ( "{0} - {1} {2} {3}", X, ( Numbers ) a1, ( Numbers ) a2, ( Numbers ) a3 );
                    }

                }
            }
            catch ( Exception ex)
            {
                Console.WriteLine (ex.Message);
            }

        }
    }
}
