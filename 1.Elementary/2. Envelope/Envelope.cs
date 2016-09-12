using System;

namespace _2.Envelope
{
    struct Envelope
    {
        private float longSide;

        public float LongSide
        {
            get { return longSide; }
            set
            {
                try
                {
                    if ( value <= 0 )
                    {
                        throw new ArgumentOutOfRangeException ( string.Format ( "Long side '{0}' of the envelope isn't valid.", value.ToString ( ) ) );
                    }
                    longSide = value;
                }
                catch ( ArgumentOutOfRangeException ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        private float shortSide;

        public float ShortSide
        {
            get { return shortSide; }
            set
            {
                try
                {
                    if ( value <= 0 )
                    {
                        throw new ArgumentOutOfRangeException ( string.Format ( "Short side '{0}' of the envelope isn't valid.", value.ToString ( ) ) );
                    }
                    shortSide = value;
                }
                catch ( ArgumentOutOfRangeException ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        public Envelope ( float a, float b ) : this()
        {
            if ( a <= b )
            {
                ShortSide = a;
                LongSide = b;
            }
            else
            {
                ShortSide = b;
                LongSide = a;
            }
        }



        public override string ToString ( )
        {
            return string.Format ( "(Envelope: {0} x {1})", shortSide, longSide );
        }


    }
}
