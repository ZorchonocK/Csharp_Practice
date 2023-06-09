using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1лаба
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double a = 1;
            double z = 0;
            int i = 1;
            Console.WriteLine("Выбирайте метод, цифра от 1 до 3");
            string selection = Console.ReadLine();
            switch (selection)
            { /*1u metodh*/
                case "1":
                    for (i = 1; i < 22; i++)
                    {
                        z = 0;
                        z = 2 * Math.Sqrt(2) * Math.Cos(a) * Math.Sin((Math.PI/4)+2*a);
                        Console.WriteLine($"Для {Math.Round(a, 3)} формула будет равна = {Math.Round(z, 3)}");
                        a = a + 0.1;
                    }
                    break;
                /*2u metodh*/
                case "2":
                    while (i < 122)
                    {
                        z = 0;
                        z = 2 * Math.Sqrt(2) * Math.Cos(a) * Math.Sin((Math.PI / 4) + 2 * a);
                        Console.WriteLine($"Для {Math.Round(a, 3)} формула будет равна = {Math.Round(z, 3)}");
                        a = a + 0.1;
                        i++;
                    }
                    break;
                /*3u metodh*/
                case "3":
                    do
                    {
                        z = 0;
                        z = 2 * Math.Sqrt(2) * Math.Cos(a) * Math.Sin((Math.PI / 4) + 2 * a);
                        Console.WriteLine($"Для {Math.Round(a, 3)} формула будет равна = {Math.Round(z, 3)}");
                        a = a + 0.1;
                        i++;
                    }
                    while (i < 22);
                    break;
                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
            Console.ReadKey();
        }
    }
}
