using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//        /*	2. Создание массива из 20-ти первых чисел Фибоначчи и выведение его на экран.
//              Напоминаем, что первый и второй члены последовательности равны 
//              единицам, а каждый следующий — сумме двух предыдущих.*/
//        int amount = 20;
//        int [ ] fibonachyArray = new int [ amount ];
//        fibonachyArray [ 0 ] = fibonachyArray [ 1 ] = 1;
//        for ( int i = 2; i < amount; i++ )
//        {
//            fibonachyArray [ i ] = fibonachyArray [ i - 2 ] + fibonachyArray [ i - 1 ];
//        }
//        System.out.println ( Arrays.toString ( fibonachyArray ) );
//        System.out.println ( );
//        break;

//     8.	Ряд Фибоначчи для диапазона

//Программа позволяет вывести все числа Фибоначчи, которые находятся в указанном диапазоне.
//Диапазон задаётся двумя аргументами при вызове главного класса.
//Числа выводятся через запятую по возрастанию.


//    Общие требования
//1.	При передаче некорректных параметров на исполнение приложение не должно завершать работу сбоем.
//2.	Запуск без параметров выводит инструкции по использованию программы.
//3.	Параметры передаются в порядке, приведённом в описании задания. 
namespace _8.Fibonacci
{
    class FibonacciSequence
    {
        private ICollection<long> fiboRow;



        private long numberMin;

        public long NumberMin
        {
            get { return numberMin; }
            set
            {
                if ( value < 1 )
                {
                    throw new ArgumentOutOfRangeException ( string.Format ( "Minimum number {0} is less than 1.", value ) );
                }
                numberMin = value;
            }
        }



        private long numberMax;

        public long NumberMax
        {
            get { return numberMax; }
            set
            {
                if ( value < 2 )
                {
                    throw new ArgumentOutOfRangeException ( string.Format ( "Maximum number {0} is less than 2.", value ) );
                }
                numberMax = value;
            }
        }



        public FibonacciSequence ( )
        {
            try
            {
                Console.WriteLine ( File.ReadAllText ( "spec.txt" ) );
            }
            catch ( FieldAccessException ex )
            {
                Console.WriteLine ( ex.Message );
            }
        }



        public FibonacciSequence ( long nMin, long nMax )
        {
            try
            {
                if ( nMin >= nMax )
                {
                    throw new ArgumentOutOfRangeException ( string.Format ( "Range {0} - {1} is not valid.", nMin, nMax ) );
                }
                this.NumberMin = nMin;
                this.NumberMax = nMax;

                fiboRow = new List<long> ( );
                getSequence ( );

                foreach ( var n in fiboRow )//////////////////////////////
                {
                    Console.WriteLine ( n );
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine ( ex.Message );
            }
        }


        private void getSequence ( )
        {
            fiboRow.Add ( 1 );
            fiboRow.Add ( 1 );
            int numberMinIndex = 0;
            int j = 2;
            while ( true )
            {
                long current = fiboRow.LastOrDefault ( ) + ( fiboRow as List<long> ) [ fiboRow.Count - 2 ];
                if ( current < numberMin )
                {
                    numberMinIndex = j;
                }
                if ( current > NumberMax )
                {
                    break;
                }
                fiboRow.Add ( current );
                j++;
            }
            ( fiboRow as List<long> ).RemoveRange ( 0, numberMinIndex + 1 );


        }



    }
}
