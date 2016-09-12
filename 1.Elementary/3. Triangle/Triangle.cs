using System;

namespace _3.Triangle
{
    struct Triangle: IComparable<Triangle>
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    if ( string.IsNullOrEmpty ( value ) == true )
                    {
                        throw new ArgumentOutOfRangeException ( string.Format ( "Name {0} is not valid.", value ) );
                    }
                    name = value;
                }
                catch ( Exception ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        private double a;

        public double A
        {
            get { return a; }
            set
            {
                try
                {
                    if ( value <= 0 )
                    {
                        throw new ArgumentOutOfRangeException ( string.Format ( "Side {0} is not valid.", value ) );
                    }
                    a = value;
                }
                catch ( Exception ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        private double b;

        public double B
        {
            get { return b; }
            set
            {
                try
                {
                    if ( value <= 0 )
                    {
                        throw new ArgumentOutOfRangeException ( string.Format ( "Side {0} is not valid.", value ) );
                    }
                    b = value;
                }
                catch ( Exception ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        private double c;

        public double C
        {
            get { return c; }
            set
            {
                try
                {
                    if ( value <= 0 )
                    {
                        throw new ArgumentOutOfRangeException ( string.Format ( "Side {0} is not valid.", value ) );
                    }
                    c = value;
                }
                catch ( Exception ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        public Triangle ( string name, double a, double b, double c ) : this ( )
        {
            if ( c <= Math.Abs ( a - b ) || c >= a + b )
            {
                throw new ArgumentOutOfRangeException ( string.Format ( "Triangle can't be created cause of side sizes." ) );
            }
            Name = name;
            A = a;
            B = b;
            C = c;
        }


        /// <summary>
        /// Gerona formula is used to calculate a triangle area.
        /// </summary>
        /// <returns></returns>
        public double getArea ( )
        {
            double p = ( a + b + c ) / 2;
            return Math.Sqrt ( p * ( p - a ) * ( p - b ) * ( p - c ) );
        }



        public override string ToString ( )
        {
            return string.Format ( "[Triangle {0}, {2}, {3}, {4}]: {1} cm", name, this.getArea ( ), a,b,c );
        }


        
        public int CompareTo ( Triangle t2 )
        {
            if ( this.getArea ( ) > t2.getArea ( ) )
            {
                return -1;
            }
            else if ( t2.getArea ( ) > this.getArea ( ) )
            {
                return 1;
            }
            return 0;
        }


    }
}
