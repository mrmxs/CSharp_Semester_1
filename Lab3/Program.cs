using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static int ReadInt32inBoards(int minBoard, int maxBoard)
        {
            int intToReturn = 0;
            string input = "";
            do
            {
                input = Console.ReadLine();
                try
                {
                    intToReturn = checked(Int32.Parse(input));
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine("Нужно число от {0} до {1}", minBoard, maxBoard);
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный ввод числа. Попробуй еще");
                }

                if (intToReturn < minBoard | intToReturn > maxBoard)
                    Console.WriteLine("Нужно число от -{0} до {1}", minBoard, maxBoard);

            } while (!Int32.TryParse(input, out intToReturn) || 
                     (intToReturn < minBoard | intToReturn > maxBoard));
            //success 

            return intToReturn;
        }
        
        #region Code for Task 1 here
        static void Task1()
        {
            int board = 100;

            #region user 1 dialog
            Console.WriteLine("Привет! Как тебя зовут?");
            string user1 = Console.ReadLine();
            Console.WriteLine("{0}, придумай число от -{1} до {1}?", user1, board);

            int secret = 0;
            do
            {
                secret = ReadInt32inBoards(-board, board);

                if (secret > board | secret < -1 * board)
                {
                    Console.WriteLine("Нужно число от -{0} до {0}", board);
                }

            } while (secret > board | secret < -1 * board);

            Console.WriteLine("{0}, передай управление другому пользователю", user1);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region user 2 dialog
            Console.WriteLine("Привет! Как тебя зовут?");
            string user2 = Console.ReadLine();
            Console.WriteLine("{0}, угадай число от -{1} до {1}?", user2, board);

            int suggest = 0;
            do
            {
                suggest = ReadInt32inBoards(-board, board);

                if (suggest > board | suggest < -board)
                {
                    Console.WriteLine("Нужно число от -{0} до {0}", board);
                }
                else if (suggest != secret)
                    Console.WriteLine(suggest > secret ?
                        "Загаданное число меньше твоего. Попробуй угадать снова" :
                        "Загаданное число больше твоего. Попробуй угадать снова");

            } while (suggest != secret);
            Console.WriteLine(
                "\nУра! {0}, ты угадал!\n{1} - именно то число, которое загадал {2}.", 
                user2, suggest, user1);

            Console.ReadKey();
            #endregion

        }
        #endregion

        #region Code for Task 2 here
        static void Task2()
        {
            Console.WriteLine("Введите год от {0} до {1}.", YEAR.minYear, YEAR.maxYear);
            YEAR.year = ReadInt32inBoards(YEAR.minYear, YEAR.maxYear);
            Console.WriteLine(
                "======================\n" +
                "Год: {0}\n\t{1}високосный год\n\tДней в году: {2}" +
                "\n=====================",
                YEAR.year, 
                YEAR.IsLeapYear()  ? "" : "не ",
                YEAR.DaysInYear());
                
            Console.WriteLine("Введите номер дня в году");
            YEAR.day = ReadInt32inBoards(0, YEAR.DaysInYear());

            Console.WriteLine(
                "======================\n" +
                "День {0} в году {1}\n\tЧисло, месяц: {2} {3}" +
                "\n=====================",
                YEAR.day, YEAR.year,
                YEAR.DateOfDay()[0], YEAR.StringMounth(1),
                YEAR.DaysInYear());

            Console.ReadKey();
        }

        struct YEAR
        {
            public static int minYear = 8;
            public static int maxYear = 5000;
            public static int year = 2016;
            public static int day = 1;
            /// <summary>
            /// day, mounth
            /// </summary>
            //public static int[] date = { 1, 1 };

            public static bool IsLeapYear()
            {
                return (year - 8) % 4 == 0;
            }

            public static int DaysInYear()
            {
                return IsLeapYear() ? 366 : 365;
            }

            public static int DaysInMounth(int mounthNum)
            {
                int[] mounth30 = { 4, 6, 9, 11 };
                int[] mounth31 = { 1, 3, 5, 7, 8, 10, 12 };

                return
                    mounth31.Contains(mounthNum) ? 31 :
                    mounth30.Contains(mounthNum) ? 30 :
                    mounthNum == 2 ?
                        (IsLeapYear() ? 29 : 28) : 0;
            }

            public static /*void*/ int[] DateOfDay()
            {
                int d = YEAR.day;
                int m = 1;
                do
                {
                    d -= DaysInMounth(m);
                    m++;
                } while (d - DaysInMounth(m) > 0);

                //date = new int[] { d, m};

                return new int[] { d, m };
            }

            public static string StringMounth(int padezh)
            {
                string[,] mounthsByPadezh = {
                    { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" },
                    { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" }
                };

                if (padezh < 0 | padezh >= mounthsByPadezh.Length) padezh = 0;

                return
                    mounthsByPadezh[
                    padezh,
                    (DateOfDay()[1] - 1)];
            }
        }
        #endregion

            static void Main(string[] args)
        {
            /// 1. Разработать консольное приложение,
            /// позволяющее одному пользователю загадывать число
            /// в заданном диапазоне, а другому отгадывать это число, 
            /// вводя произвольные числа с последующим указанием того, 
            /// больше это число загаданного или нет.
            Task1();

            /// 2. Разработать приложение, определяющее дату 
            /// в формате «число месяц» по номеру дня в году, 
            /// вводимому с консоли. 
            /// Приложение дополнительно должно запрашивать с консоли 
            /// информацию о номере года для определения того,
            /// является ли год високосным. Не использовать тип DateTime. 
            /// Предусмотреть проверку номера дня в году на попадание
            /// в диапазон от 1 до 365 или от 1 до 366 для високосных годов.
            /// Результат выводить на консоль.
            Task2();

        }
    }
}
