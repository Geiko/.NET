using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.HappyTicket
{
    class CountHappyTicket
    {
        private enum AlgorithmType { Moskow, Piter }
        ICollection<Ticket> tickets;



        public CountHappyTicket ( )
        {
            Console.WriteLine (File.ReadAllText("task.txt"));
        }



        public CountHappyTicket ( List<Ticket> tickets )
        {
            this.tickets = tickets;
            try
            {
                AlgorithmType algorithm = getAlgorithmType ( );
                int happyTicketsAmount = countTickets ( tickets, algorithm );                
                Console.WriteLine ( "Happy tickets amount - {0}", happyTicketsAmount);
            }
            catch ( ArgumentNullException ex )
            {
                Console.WriteLine ( ex.Message );
            }
            catch ( IOException ex )
            {
                Console.WriteLine ( ex.Message );
            }
        }



        private AlgorithmType getAlgorithmType ( )
        {
            string algorithm = File.ReadAllText ( "algorithm.txt" );
            if ( algorithm == "Moskow" )
            {
                return AlgorithmType.Moskow;
            }
            else if ( algorithm == "Piter" )
            {
                return AlgorithmType.Piter;
            }
            else
            {
                throw new ArgumentNullException ( "Algorithm is not read correctly '{0}'.", algorithm );
            }
        }

        

        private int countTickets ( List<Ticket>tickets, AlgorithmType algorithm )
        {
            int happyTicketsAmount = 0;
            foreach ( Ticket t in tickets )
            {
                Console.WriteLine (t.Number);
                int digitAmount = t.Number.Length;
                int [ ] digits = new int [ digitAmount ];
                for ( int i = 0; i < digitAmount; i++ )
                {
                    digits [ i ] = (int) Char.GetNumericValue ( t.Number [ i ]) ;
                }

                int sum1, sum2;
                countSums (  digits, algorithm, out sum1, out  sum2 );
                if ( sum1 == sum2 )
                {
                    happyTicketsAmount++;
                }
                Console.WriteLine ("--------");
            }
            Console.WriteLine ( happyTicketsAmount );
            return happyTicketsAmount;
        }



        private void countSums (  int [ ] digits, AlgorithmType algorithm, out int sum1, out int sum2 )
        {
            if ( algorithm ==  AlgorithmType.Moskow )
            {
                Console.WriteLine ( "MOSKOW" );
                int sum = 0;
                for ( int i = 0; i < digits.Length / 2; i++ )
                {
                    sum += digits [ i ];
                }
                sum1 = sum;

                sum = 0;
                int start = digits.Length / 2;
                if(digits.Length % 2 != 0 )
                {
                    start++;
                }
                for ( int i = start; i < digits.Length; i++ )
                {
                    sum += digits [ i ];
                }
                sum2 = sum;
                Console.WriteLine ( sum1 + " - " + sum2 + " :      " + (sum1==sum2) );
            }
            else if ( algorithm == AlgorithmType.Piter )
            {
                sum1 = -2;
                sum2 = -2;
                Console.WriteLine ("PITER");
            }
            else
            {
                sum1 = -3;
                sum2 = -3;
            }
        }
    }
}