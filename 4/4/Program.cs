using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class ClassLibrary
    {
        public static void IsPrime(int A)
        {
            bool bl = true;
            for (int i = 2; i < Math.Sqrt(A) + 1; i++)
                if ((A % i) == 0)
                {
                    ArefmProgr.Funk(A);
                    bl = false;
                    break;
                }

            if (bl)
            {
                GeomertProgr.Funk(A);
            }

            Coordinate AB;
            Coordinate BC;
            Coordinate AC;

            Console.Write("AB.x: ");
            AB.x = int.Parse(Console.ReadLine());
            Console.Write("AB.y: ");
            AB.y = int.Parse(Console.ReadLine());

            Console.Write("BC.x: ");
            BC.x = int.Parse(Console.ReadLine());
            Console.Write("BC.y: ");
            BC.y = int.Parse(Console.ReadLine());

            Console.Write("AC.x: ");
            AC.x = int.Parse(Console.ReadLine());
            Console.Write("AC.y: ");
            AC.y = int.Parse(Console.ReadLine());

            double perimeter = Length(AB.x, AB.y, BC.x, BC.y) + Length(AC.x, AC.y, BC.x, BC.y) + Length(AB.x, AB.y, AC.x, AC.y);
            Console.Write("Периметр равен ");
            Console.Write(perimeter);

        }

        public static double Length(int x1, int y1, int x2, int y2)
        {

            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }




        struct Coordinate
        {
            public int x;
            public int y;
        }

    }


    class ArefmProgr
    {
        public static void Funk(int endElem)
        {
            Console.WriteLine("Арифметическая прогрессия запущенна...");
            double[] ArefmProgrArray = new double[endElem];
            double firstElem = 1;
            ArefmProgrArray[0] = firstElem;
            double ArefmSumElem = firstElem;
            double stepOfElem = 5;

            for (int i = 1; i < endElem; i++)
            {
                ArefmProgrArray[i] = ArefmProgrArray[0] + (i - 1) * stepOfElem;
                Console.Write(ArefmProgrArray[i] + " ");
                ArefmSumElem += ArefmProgrArray[i];
            }
            Console.WriteLine("\nХарактеристики: \nпервый член = {0} \nшаг = {1} \nномер последнего члена = {2}", firstElem, stepOfElem, endElem);
            Console.WriteLine("Sum= " + ArefmSumElem);
        }
    }

    public class GeomertProgr
    {
        public static void Funk(int endElem)
        {
            Console.WriteLine("Геометрическая прогрессия запущенна...");
            double[] ArefmProgrArray = new double[endElem];
            double firstElem = 1;
            ArefmProgrArray[0] = firstElem;
            double ArefmSumElem = firstElem;


            for (int i = 1; i < endElem; i++)
            {
                ArefmProgrArray[i] = Math.Pow(ArefmProgrArray[0], i);
                Console.Write(ArefmProgrArray[i] + " ");
                ArefmSumElem += ArefmProgrArray[i];
            }
            Console.WriteLine("\nХарактеристики: \nпервый член = {0}\nномер последнего члена = {1}", firstElem, endElem);
            Console.WriteLine("Sum= " + (ArefmSumElem + firstElem));
        }
    }

    class ClassTest
    {
        static void Main()
        {
            Console.WriteLine("Введите число для проверки: ");
            int x = Convert.ToInt32(Console.ReadLine());
            ClassLibrary.IsPrime(x);
            Console.ReadKey();
        }
    }

}
