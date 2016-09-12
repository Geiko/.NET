using System;
using System.Collections.Generic;

/*
    1.	При передаче некорректных параметров на исполнение приложение не должно завершать работу сбоем.
    2.	Запуск без параметров выводит инструкции по использованию программы.
    3.	Параметры передаются в порядке, приведённом в описании задания.

    2.	Анализ конвертов
    Есть два конверта со сторонами (a,b) и (c,d) определить, можно ли один конверт вложить в другой.     
    Программа должна обрабатывать ввод чисел с плавающей точкой. 
    
    Программа спрашивает у пользователя размеры конвертов по одному параметру за раз. 
    После каждого подсчёта программа спрашивает у пользователя хочет ли он продолжить. 

    Если пользователь ответит “y” или “yes” (без учёта регистра), 
    программа продолжает работу сначала, в противном случае – завершает выполнение.
 */
namespace _2.Envelope
{
    class EnvelopeNesting
    {
        private ICollection<Envelope> envelops;
        private const int ENVELOPE_QUANTITY = 2;



        public EnvelopeNesting ( )
        {
            while ( true )
            {
                envelops = new List<Envelope> ( ENVELOPE_QUANTITY );

                try
                {
                    gettingEnvelopes ( );
                    nesting ( );
                }
                catch ( ArgumentNullException ex )
                {
                    Console.WriteLine ( ex.Message );
                }

                if ( isContinue ( ) == false )
                {
                    break;
                }
            }
        }



        private void gettingEnvelopes ( )
        {
            for ( int i = 0; i < ENVELOPE_QUANTITY; i++ )
            {
                Console.WriteLine ( "Envelope {0}.", i + 1 );
                Envelope? envelope = inputEnvelopeParams ( );
                if ( envelope == null )
                {
                    throw new ArgumentNullException ( "Envelope is null." );
                }

                envelops.Add ( ( Envelope ) envelope );
            }
        }



        private Envelope? inputEnvelopeParams ( )
        {
            float? a = inputSide ( );
            if ( a != null )
            {
                float? b = inputSide ( );
                if ( b != null )
                {
                    return new Envelope ( ( float ) a, ( float ) b );
                }
            }
            return null;
        }



        private float? inputSide ( )
        {
            while ( true )
            {
                Console.WriteLine ( "Please, input the side size (float) of the envelope \n or input 'out' to leave the application." );
                string customerSize = Console.ReadLine ( );
                if ( customerSize == "out" )
                {
                    Console.WriteLine ( "By!" );
                    return null;
                }
                float number;
                bool result = float.TryParse ( customerSize, out number );
                if ( result == true )
                {
                    return number;
                }
                Console.WriteLine ( "You've input {0} that is not valid.", customerSize );
            }
        }



        private void nesting ( )
        {
            Console.WriteLine ( "NESTING" );
            var es = envelops as List<Envelope>;

            if ( es [ 0 ].LongSide < es [ 1 ].LongSide   &&   es [ 0 ].ShortSide < es [ 1 ].ShortSide )
            {
                Console.WriteLine ( "Envelope 1 {0} is nested in the envelope 2 {1}.", es [ 0 ], es [ 1 ] );
            }
            else if ( es [ 0 ].LongSide > es [ 1 ].LongSide   &&   es [ 0 ].ShortSide > es [ 1 ].ShortSide )
            {
                Console.WriteLine ( "Envelope 2 {1} is nested in the envelope 1 {0}.", es [ 0 ], es [ 1 ] );
            }
            else
            {
                Console.WriteLine ( "Envelops can't be nested into each other. {0} - {1}", es [ 0 ], es [ 1 ] );
            }
        }



        private bool isContinue ( )
        {
            Console.WriteLine ( "Would you like to continue?" );
            string answer = Console.ReadLine ( );
            if ( answer.ToLower ( ) == "y" || answer.ToLower ( ) == "yes" )
            {
                return true;
            }
            return false;
        }
    }
}
