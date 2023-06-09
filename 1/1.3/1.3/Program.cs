using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mena_mestami
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            int[,] mas = new int[n, n];
            int sum = 0;
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas[i, j] = rnd.Next(-50, 51);
                    if (mas[i, j] < 0) sum = sum + mas[i, j];
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(" sum = {0}", sum);

            Console.ReadKey(true);
        }
    }
}