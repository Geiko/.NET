using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.Triangle
{
    class TriangleSorting
    {
        private ICollection<Triangle> triangles;



        public TriangleSorting ( )
        {
            triangles = new List<Triangle> ( );
            while ( true )
            {
                inputNewTriangle ( );               
                if ( isContinue ( ) == false )
                {
                    break;
                }
            }
            sortTriangles ( );
            showTriangles ( );
        }



        private void inputNewTriangle ( )
        {
            Triangle? triangle = inputTriangleParams();
            if ( triangle == null )
            {
                Console.WriteLine ( string.Format ( "New triangle is null." ) );
            }
            else
            {
                triangles.Add ( ( Triangle ) triangle );
            }
        }



        private Triangle? inputTriangleParams ( )
        {
            while ( true )
            {
                Console.WriteLine ( "Please, input parametres of new triangle or input 'out'." );
                Console.WriteLine ( " Format: < имя >, < длина стороны >, < длина стороны >, < длина стороны > " );
                string input = Console.ReadLine ();
                if ( input.Trim().ToLower() == "out" )
                {
                    return null;
                }
                Triangle? triangle =  parseInput ( input );
                if ( triangle != null )
                {
                    return triangle;
                }
                Console.WriteLine ( "Your input is not valid." );
            }
        }



        private Triangle? parseInput ( string input )
        {
            Regex regex = new Regex ( @"<.*?>" );
            MatchCollection parameters = regex.Matches ( input );

            int paramQuantity = parameters.Count;
            if ( paramQuantity != 4 )
            {
                Console.WriteLine ( "You've input {0} parameters. Must be 4.", paramQuantity );
                return null;
            }

            string [ ] triangleParameters = new string [ 4 ];
            for ( int i = 0; i < paramQuantity; i++ )
            {
                string str = parameters [ i ].Value;
                str = Regex.Replace ( str, "^<| |>$", "" );
                str = str.Trim('\t');
                triangleParameters [ i ] = str;
            }

            try
            {
                string name =   triangleParameters [ 0 ];
                double a =      triangleParameters [ 1 ].convertToDouble ( );
                double b =      triangleParameters [ 2 ].convertToDouble ( );
                double c =      triangleParameters [ 3 ].convertToDouble ( );
                //Console.WriteLine ($"{a} - {b} - {c}");

                return new Triangle ( name, a, b, c );
            }
            catch ( ArgumentException ex)
            {
                Console.WriteLine (ex.Message);
                return null;
            }
        }



        private bool isContinue ( )
        {
            Console.WriteLine ( "Would you like to add new triangle?" );
            string userAnswer = Console.ReadLine ( );
            if ( userAnswer.ToLower ( ) == "y" || userAnswer.ToLower ( ) == "yes" )
            {
                return true;
            }
            return false;
        }



        private void sortTriangles ( )
        {
            ( triangles as List<Triangle> ).Sort();

            //( triangles as List<Triangle> ).Sort 
            //    (
            //        delegate ( Triangle t1, Triangle t2 )
            //        {
            //            return t2.getArea ( ).CompareTo ( t1.getArea ( ) );
            //        }
            //    );

            //triangles  =  triangles.OrderByDescending ( t => t.getArea() ).ToList ( );
        }



        private void showTriangles ( )
        {
            Console.WriteLine ( "============= Triangles list: ===============" );
            int i = 0;
            foreach ( Triangle triangle in triangles )
            {
                i++;
                Console.WriteLine ("{0}. {1}", i, triangle);
            }
        }
    }


}
