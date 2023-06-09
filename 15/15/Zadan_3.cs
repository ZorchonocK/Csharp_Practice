using System;
using System.Threading;
namespace _15
{
    public class Zadan_3
    {
            public static void ZadanMain_3()
        {
            double[,] matrix = {
                { 1.5, 2.7, 3.2 },
                { 4.1, 2.7, 5.3 },
                { 1.5, 6.2, 3.2 }
            };

            double targetElement = 2.7;

            Thread[] threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    MatrixSearchTask task = new MatrixSearchTask(matrix, targetElement);

                    int count = task.Search();
                    Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: Количество вхождений элемента {targetElement} = {count}");
                });

                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("Все потоки завершили работу.");
        }
    }

    class MatrixSearchTask
    {
        private double[,] matrix;
        private double targetElement;

        public MatrixSearchTask(double[,] matrix, double targetElement)
        {
            this.matrix = matrix;
            this.targetElement = targetElement;
        }

        public int Search()
        {
            int count = 0;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == targetElement)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}

   

