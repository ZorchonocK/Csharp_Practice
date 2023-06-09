using System;
namespace _13
{
	public class Zadan_2
	{
        public delegate int[] MyDelegate(int arraySize);

        public static void zadanMain_2()
        {
            int arraySize = 100;
            MyDelegate myDelegate2 = GetDivisibleByThreeSubset;

            Task<int[]> task = Task.Run(() => myDelegate2(arraySize));

            while (!task.IsCompleted)
            {
                Console.WriteLine("Выполняется...");
                Thread.Sleep(500);
            }

            int[] result = task.Result;

            Console.WriteLine("Результат:");
            foreach (int number in result)
            {
                Console.WriteLine(number);
            }
        }

        public static int[] GetDivisibleByThreeSubset(int arraySize)
        {
            Random random = new Random();
            int[] numbers = Enumerable.Range(1, arraySize)
                                      .Select(_ => random.Next(1, 100))
                                      .ToArray();

            int[] divisibleByThreeSubset = numbers.Where(n => n % 3 == 0).ToArray();

            // Симуляция длительной операции
            Thread.Sleep(3000);

            return divisibleByThreeSubset;
        }
    }
}

