using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1
{
    class PerimetrTreugolynika
    {
        struct Coordinate
        {
            public int x;
            public int y;
        }

        static void Main(string[] args)
        {
            Coordinate AB;
            Coordinate BC;
            Coordinate AC;

            try
            {
                Console.Write("Введите AB.x: ");
                AB.x = int.Parse(Console.ReadLine());
                Console.Write("Введите AB.y: ");
                AB.y = int.Parse(Console.ReadLine());

                Console.Write("Введите BC.x: ");
                BC.x = int.Parse(Console.ReadLine());
                Console.Write("Введите BC.y: ");
                BC.y = int.Parse(Console.ReadLine());

                Console.Write("Введите AC.x: ");
                AC.x = int.Parse(Console.ReadLine());
                Console.Write("Введите AC.y: ");
                AC.y = int.Parse(Console.ReadLine());

                double perimeter = Length(AB.x, AB.y, BC.x, BC.y) + Length(AC.x, AC.y, BC.x, BC.y) + Length(AB.x, AB.y, AC.x, AC.y);
                Console.WriteLine("Периметр равен = {0}", perimeter);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static double Length(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
