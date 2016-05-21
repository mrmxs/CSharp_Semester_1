using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Task(int taskNum)
        {
            switch (taskNum)
            {
                case 1:
                    //Запросить через консоль имя человека, а затем поздороваться с этим человеком
                    Console.WriteLine("task 1\n" +
                        "Запросить через консоль имя человека, а затем поздороваться с этим человеком");
                    Console.WriteLine("Как тебя зовут?");
                    string a = Console.ReadLine();
                    Console.WriteLine("Привет, {0}!", a.ToUpper());
                    break;
                case 2:
                    //Изменить цвет фона и символов
                    Console.WriteLine("task 2\n" +
                        "Изменить цвет фона и символов");
                    Console.ReadKey();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Цвет фона: ConsoleColor.Yellow,\nЦвет текста: ConsoleColor.DarkGreen");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
                case 3:
                    //Установить название окна консоли в соответствии с именем студента
                    Console.WriteLine("task 3\n" +
                        "Установить название окна консоли в соответствии с именем студента");
                    Console.ReadKey();
                    Console.Title = "Lab 1 by Mary Maxs";
                    break;
                case 4:
                    //Установить размер окна консоли 50 х 50
                    Console.WriteLine("task 4\n" +
                        "Установить размер окна консоли 50 х 50");
                    Console.SetWindowSize(50, 50);
                    Console.ReadKey();
                    Console.SetWindowSize(80, 25);
                    break;
                case 5:
                    //Выдать звуковой сигнал
                    Console.WriteLine("task 5\n" +
                        "Выдать звуковой сигнал");
                    Console.ReadKey();
                    for (int i = 110; i < 600; i += 25)
                    {
                        Console.Beep(i, 100);
                        Console.Write("{0} ", i);
                    }
                    Console.WriteLine();
                    break;
                case 6:
                    //Отобразить состояние CapsLock и NumLock
                    Console.WriteLine("task 6\n" +
                        "Отобразить состояние CapsLock и NumLock");
                    Console.WriteLine("Установите неоходимое значение CapsLock и NumLock");
                    Console.ReadKey();
                    Console.WriteLine("Caps Lock: " + (Console.CapsLock ? "On" : "Off"));
                    Console.WriteLine("Num Lock: " + (Console.NumberLock ? "On" : "Off"));
                    break;
                case 7:
                    //Скрыть курсор
                    Console.WriteLine("task 7\n" +
                        "Скрыть курсор");
                    Console.CursorVisible = false;
                    break;
                default:
                    break;
            }

        }
        static void Next()
        {
            Console.WriteLine("\npress for the next");
            Console.ReadKey();
            Console.Clear();
        }


        static void Main(string[] args)
        {
            for (int i = 1; i < 8; i++)
            {
                Task(i);
                if (i != 7)
                    Next();
                else
                    Console.ReadKey(); ;
            }
        }
    }
}
