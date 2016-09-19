using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
     8.	Ряд Фибоначчи для диапазона

    Программа позволяет вывести все числа Фибоначчи, которые находятся в указанном диапазоне. 
    Диапазон задаётся двумя аргументами при вызове главного класса. 
    Числа выводятся через запятую по возрастанию.
    
        Общие требования
    1.	При передаче некорректных параметров на исполнение приложение не должно завершать работу сбоем.
    2.	Запуск без параметров выводит инструкции по использованию программы.
    3.	Параметры передаются в порядке, приведённом в описании задания. 
*/

namespace _8.Fibonacci
{
    class Program
    {
        static void Main ( string [ ] args )
        {
            try
            {
                new FibonacciSequence ( );
                new FibonacciSequence (100, 1000 );
            }
            catch ( OutOfMemoryException ex)
            {
                Console.WriteLine ( ex.Message );
            }
        }
    }
}
