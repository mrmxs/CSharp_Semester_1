using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab2
{
    class Program
    {
        public static string Funct(short fNum, float x)
        {
            switch (fNum)
            {
                case 1:
                    Console.Write("x + 2 * x * x - 3 = ");
                    return (x + 2 * x * x - 3).ToString();
                case 2:
                    Console.Write("x * x * x – 4 * x = ");
                    return (x * x * x - 4 * x).ToString();
                case 3:
                    Console.Write("3 + 2 * x * x – 4 * x * x * x = ");
                    return (3 + 2 * x * x - 4 * x * x * x).ToString();
                case 4:
                    Console.Write("6 * x – x – 4 * x * x = ");
                    return (6 * x - x - 4 * x * x).ToString();
                case 5:
                    Console.Write("3 – x + 2 * x * x * x = ");
                    return (3 - x + 2 * x * x * x).ToString();
                case 6:
                    Console.Write("4 * x * x + 3 * x – 5 = ");
                    return (4 * x * x + 3 * x - 5).ToString();
                case 7:
                    Console.Write("2 * x – 3 * x * x * x + 3 = ");
                    return (2 * x - 3 * x * x * x + 3).ToString();
                case 8:
                    Console.Write("3 * x * x + 4 * x * x – 2 * x + 1 = ");
                    return (3 * x * x + 4 * x * x - 2 * x + 1).ToString();
                case 9:
                    Console.Write("2 * x + 4 – 5 * x * x = ");
                    return (2 * x + 4 - 5 * x * x).ToString();
                case 10:
                    Console.Write("4 * x + 3 * x * x - 5 = ");
                    return (4 * x + 3 * x * x - 5).ToString();
            }
            return "function not exist";
        }

        enum music_ganre {
            blues, classic, dance,
            disco, electronic,
            grunge, hip_hop, indie,
            industrial, jazz, metal,
            new_age, pop, punk,
            r_n_b, rap, reggae,
            rock, soul, soundtrack,
            techno}

        #region structs
        struct Square
        {
            private static int x1;
            private static int y1;
            private static int x2;
            private static int y2;

            public static void Init()
            {
                Console.Write("Введите x1... ");
                x1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите y1... ");
                y1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите x2... ");
                x2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите y2... ");
                y2 = Convert.ToInt32(Console.ReadLine());
            }

            public static double S()
            {
                //diagonal^2/2
                return (Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1),2))/2;
            }

            public static double P()
            {
                //4*diagonal/sqrt(2)
                //return 4 * Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)) / Math.Sqrt(2); 
                return 4 * Math.Sqrt(
                    (Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)) / 2);
            }
        }
        
        struct Circle
        {
            private static int cx;
            private static int cy;
            private static int x;
            private static int y;
            private static double r;

            public static void Init()
            {
                Console.Write("Введите cx... ");
                cx = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите cy... ");
                cy = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите x... ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите y... ");
                y = Convert.ToInt32(Console.ReadLine());
               
                r = Math.Sqrt(Math.Pow((x - cx), 2) + Math.Pow((y - cy), 2));
            }

            public static double R()
            {
                return r;
            }

            public static double S()
            {
                //pi*r^2
                return Math.PI * r * r;
            }

            public static double P()
            {
                //2*pi*r
                return 2 * Math.PI * r;
            }

        }
        #endregion 

        static void Main(string[] args)
        {
            #region task 1
            Console.WriteLine("task1\nРассчитать значение функции в заданной точке.");
            Console.WriteLine("Введите значение x.");
            float x = Convert.ToSingle(Console.ReadLine());
            for (short i = 1; i < 10; i++)
                Console.WriteLine(Funct(i, x));
            Console.WriteLine("press for the next");
            Console.ReadKey();
            #endregion

            #region task 2
            Console.WriteLine("task2\nИспользовать перечислимый тип для хранения названий музыкальных жанров с последующей печатью на экране значений созданного перечислимого типа.");
            for (short i = 0; i < 20; i++)
                Console.WriteLine("{0}\t{1}", i, (music_ganre)i);
            Console.WriteLine("\npress for the next");
            Console.ReadKey();
            #endregion

            #region task 3
            Console.WriteLine("SQUARE");
            Square.Init();
            Console.WriteLine("S = {0}", Square.S());
            Console.WriteLine("P = {0}\n", Square.P());
            Console.ReadKey();

            Console.WriteLine("CIRCLE");
            Circle.Init();
            Console.WriteLine("R = {0}", Circle.R());
            Console.WriteLine("S = {0}", Circle.S());
            Console.WriteLine("P = {0}", Circle.P());
            Console.ReadKey();

            #endregion
        }
    }
}