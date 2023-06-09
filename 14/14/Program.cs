using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static event Action<int, int> CalculationCompleted;

    static void Main()
    {
        string fibonacciFile = "fibonacci.txt";
        string primesFile = "primes.txt";

        CalculationCompleted += CalculationCompletedHandler;

        List<int> fibonacciNumbers = FindFibonacciNumbers(20);
        List<int> primeNumbers = FindPrimeNumbers(50);


        SaveNumbersToFile(fibonacciFile, fibonacciNumbers);
        SaveNumbersToFile(primesFile, primeNumbers);

        
        CalculationCompleted?.Invoke(fibonacciNumbers.Count, primeNumbers.Count);

        
        Console.WriteLine("Результаты поиска чисел Фибоначчи:");
        int fibonacciCount = AnalyzeFile(fibonacciFile);
        Console.WriteLine("Количество найденных чисел Фибоначчи: " + fibonacciCount);

        Console.WriteLine();

        Console.WriteLine("Результаты поиска простых чисел:");
        int primeCount = AnalyzeFile(primesFile);
        Console.WriteLine("Количество найденных простых чисел: " + primeCount);

        Console.ReadLine();
    }

    static List<int> FindFibonacciNumbers(int n)
    {
        List<int> fibonacciNumbers = new List<int>();

        int a = 0;
        int b = 1;

        fibonacciNumbers.Add(a);

        for (int i = 1; i < n; i++)
        {
            fibonacciNumbers.Add(b);
            int temp = a;
            a = b;
            b = temp + b;
        }

        return fibonacciNumbers;
    }

    static List<int> FindPrimeNumbers(int n)
    {
        List<int> primeNumbers = new List<int>();

        for (int i = 2; i <= n; i++)
        {
            bool isPrime = true;

            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primeNumbers.Add(i);
            }
        }

        return primeNumbers;
    }

    static void SaveNumbersToFile(string fileName, List<int> numbers)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (int number in numbers)
            {
                writer.WriteLine(number);
            }
        }
    }

    static int AnalyzeFile(string fileName)
    {
        int count = 0;

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                count++;
            }
        }

        return count;
    }

    static void CalculationCompletedHandler(int fibonacciCount, int primeCount)
    {
        Console.WriteLine("Расчет завершен. Количество найденных чисел Фибоначчи: " + fibonacciCount);
        Console.WriteLine("Количество найденных простых чисел: " + primeCount);
    }
}
