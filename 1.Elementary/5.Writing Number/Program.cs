using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Общие требования
        1.	При передаче некорректных параметров на исполнение приложение не должно завершать работу сбоем.
        2.	Запуск без параметров выводит инструкции по использованию программы.
        3.	Параметры передаются в порядке, приведённом в описании задания.


5.	Число в пропись
Нужно преобразовать целое число в прописной вариант: 12 – двенадцать. 
Программа запускается через вызов главного класса с параметрами.

    */
namespace _5.Writing_Number
{
    class Program
    {
        static void Main ( string [ ] args )
        {
            new WritingNumber ( );
            Console.WriteLine ("----------------------");
            new WritingNumber ( 2 );
            new WritingNumber ( 07 );
            new WritingNumber ( 0 );
            new WritingNumber ( 12 );
            new WritingNumber ( 23 );
            new WritingNumber ( 50 );
            new WritingNumber ( 92 );
            new WritingNumber ( 123 );
            new WritingNumber ( 300 );
            new WritingNumber ( 320 );
            new WritingNumber ( 306 );
            new WritingNumber ( 568 );
            new WritingNumber ( 999 );
        }
    }
}
