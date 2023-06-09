using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._4
{
    internal class Program
    {
        static void Main()
        {
            const int size = 5;
            Console.Write("Введите размерность массива: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            int[,] mas = new int[N, N];
            int[] masi = new int[N];
            int[] masj = new int[N];
            int count = 0, ind = 0;

            Random r = new Random();
            int[,] matrix = new int[size, size]
       {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, -12, 13, 14, 15 },
                { 16, 17, -18, -19, -20 },
                { 21, 22, 23, 24, 25 }
       };
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Исходная матрица: ");

            // Определяем сумму элементов в тех столбцах, которые не содержат отрицательных элементов
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                bool hasNegative = false;
                for (int j = 0; j < size; j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }

                if (!hasNegative)
                {
                    for (int j = 0; j < size; j++)
                    {
                        sum += matrix[j, i];
                    }
                }
            }

            Console.WriteLine("Сумма элементов в столбцах без отрицательных элементов: " + sum);

            // Определяем минимум среди сумм модулей элементов диагоналей,
            // параллельных побочной диагонали матрицы
            int minSum = int.MaxValue;
            for (int i = 1; i < size; i++)
            {
                int diagonalSum = 0;

            }


            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    mas[i, j] = r.Next(-1, 2);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(mas[i, j] + " ");
                Console.WriteLine();
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    masi[j] = mas[i, j];

                for (int m = 0; m < N; m++)
                {
                    for (int n = 0; n < N; n++)
                    {
                        if (masi[n] == mas[n, m])
                        {
                            count++;
                            ind = m;
                        }
                        else
                        {
                            count = 0;
                            break;
                        }
                    }

                    if (count == N && i == ind)
                        Console.WriteLine("\nk: " + (i + 1));
                }
            }


            Console.WriteLine("\nСумма\n");

            int amount = 0;
            bool check = false;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    amount += mas[i, j];
                    if (mas[i, j] < 0) check = true;
                }
                if (check)
                {
                    Console.WriteLine("Сумма элементов (Строка #" + i + ") = " + amount);
                    check = false;
                }
                amount = 0;
            }

            Console.ReadKey();
        }
    }
}


