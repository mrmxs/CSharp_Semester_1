using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
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
                secret = ReadInt32inBoards(board);

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
                suggest = ReadInt32inBoards(board);

                if (suggest > board | suggest < -1 * board)
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

        static int ReadInt32inBoards(int board)
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
                    Console.WriteLine("Нужно число от -{0} до {0}", board);
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный ввод числа. Попробуй еще");
                }
            } while (!Int32.TryParse(input, out intToReturn));
            //success 

            return intToReturn;
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
        }
    }
}
