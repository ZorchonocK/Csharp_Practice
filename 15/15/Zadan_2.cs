using System;
using System.Threading;
namespace _15
{
    public class Zadan_2
    {
        public static void ZadanMain_2()
        {
            int counterLimit = 10;

            Thread[] threads = new Thread[3];

            Action<int, int> countMethod = Count;

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    Thread.CurrentThread.Priority = (ThreadPriority)(i);

                    Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} создан.{Thread.CurrentThread.Priority}");

                    countMethod(counterLimit, i + 1);
                });

                threads[i].Start();
                threads[i].Join();
            }

            Console.WriteLine("Все потоки завершили работу.");
        }

        public static void Count(int limit, int threadPriority)
        {
            for (int i = 0; i <= limit; i++)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} (Приоритет: {threadPriority}): значение счетчика = {i}");
                Thread.Sleep(100);
            }
        }
    }
}
