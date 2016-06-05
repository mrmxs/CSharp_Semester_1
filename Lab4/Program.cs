using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {

        private static int ReadInt32()
        {
            int intToReturn = 0;
            string input = "";
            do
            {
                input = Console.ReadLine();
                try
                {
                    int? nullable = null;

                    intToReturn = (input != "null") ?
                        checked(int.Parse(input)) :
                        (int)nullable;
                }
                // null
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                // ввели строку вместо числа
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                // ввели больше/меньше граничных значений int
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                // не должно произойти никогда
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (!int.TryParse(input, out intToReturn));
            //success 

            return intToReturn;
        }

        private static string Function(double x)
        {
            double result = 0;
            try
            {
                // извелечение корня отрицательного числа
                if (x < 0)
                    throw new NotFiniteNumberException(
                        "Извелечение корня отрицательного числа.", x);
                // деление на ноль
                else if (x == 0)
                    throw new DivideByZeroException();
                // попытка вычисления значения функция
                else
                    result = Math.Sqrt(x) + 2 / x - 3;

                // результат — бесконечность или NaN
                if (double.IsNaN(result) || double.IsInfinity(result))
                    throw new NotFiniteNumberException();
            }
            catch (ArithmeticException e)
            {
                return e.Message;
            }
            // все остальные ошибки, которые не должны произойти
            catch (Exception e)
            {
                return e.Message;
            }

            return
                "sqrt(x) + 2/x - 3 = " + result.ToString();
        }



        static void Main(string[] args)
        {
            /// Рассчитать значение функции в заданной с консоли точке
            /// с учётом возможных ошибок её вычисления. 
            /// Учесть, что функция может иметь
            /// * деление на аргумент или 
            /// * вычисление квадратного корня, 
            /// которые могут вызвать исключение пр вычисленн.
            /// Аргумент функции вводится с консоли, 
            /// рассчитанное значение выводится на консоль.
            /// При вводе значения аргумента следует учесть, 
            /// что строка не всегда успешно преобразуется в число.
            ///
            /// x^(1/2) + 2/x - 3


            Console.WriteLine("Введите x. (Int32)");
            int x = ReadInt32();

            Console.WriteLine(Function(x));

            Console.ReadKey();
        }
    }
}
