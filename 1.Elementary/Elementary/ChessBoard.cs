using System;
using System.Text;

namespace Elementary
{
    class ChessBoard
    {
        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                try
                {
                    if ( value <= 0 )
                    {
                        throw new ArgumentOutOfRangeException ( string.Format ( "Height is not valid: {0}", value.ToString ( ) ) );
                    }
                    height = value;
                }
                catch ( ArgumentOutOfRangeException ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }

        private int width;
        public int Width
        {
            get { return width; }
            set
            {
                try
                {
                    if ( value <= 0 )
                    {
                        throw new ArgumentOutOfRangeException ( string.Format ( "Width is not valid: {0}", value.ToString ( ) ) );
                    }
                    width = value;
                }
                catch ( ArgumentOutOfRangeException ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        public ChessBoard ( )
        {
            int? customerWidth = inputSize ( "width" );
            if ( customerWidth != null )
            {
                int? customerHeight = inputSize ( "height" );
                if ( customerHeight != null )
                {
                    Width = ( int ) customerWidth;
                    Height = ( int ) customerHeight;
                    Console.WriteLine ( this );
                }
            }
        }

        private int? inputSize ( string sizeName )
        {
            while ( true )
            {
                Console.WriteLine ( "Please, input the {0} of the chess board \n or input 'out' to leave the application.", sizeName );
                string x = Console.ReadLine ( );
                if ( x == "out" )
                {
                    Console.WriteLine ( "By!" );
                    return null;
                }
                int number;
                bool result = int.TryParse ( x, out number );
                if ( result == true )
                {
                    return number;
                }
                Console.WriteLine ( "You've input {0} that is not valid.", sizeName );
            }
        }



        public ChessBoard ( int width, int height )
        {
            Width = width;
            Height = height;
            Console.WriteLine ( this );
        }



        public override string ToString ( )
        {
            StringBuilder sb = new StringBuilder ( );
            for ( int i = 0; i < Height; i++ )
            {
                for ( int j = 0; j < Width; j++ )
                {
                    if ( ( j % 2 == 0 && i % 2 == 0 ) || ( j % 2 != 0 && i % 2 != 0 ) )
                    {
                        sb.Append ( "*" );
                    }
                    else if ( ( j % 2 == 0 && i % 2 != 0 ) || ( j % 2 != 0 && i % 2 == 0 ) )
                    {
                        sb.Append ( " " );
                    }
                }
                sb.Append ( "\n" );
            }
            return sb.ToString ( );
        }
    }
}