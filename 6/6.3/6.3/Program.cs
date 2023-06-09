using System;

class Cyberforum
{
    static void Main()
    {
        const int N = 8;                    // 3 для проверки, по заданию нужно изменить на 8
        int[,] mas = new int[N, N];          // при увеличении N вероятность появления k стремится к 0
        int[] masi = new int[N];
        int[] masj = new int[N];
        int count = 0, ind = 0;

        Random r = new Random();

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                mas[i, j] = r.Next(-5, 5);   // диапазон для проверки, изменять по желанию
                                             // при увеличении границ диапазона вероятность появления k стремится к нулю
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

        // Сумма элементов в строках с отр. элементом(ми)
        Console.WriteLine("\n\nAmounts\n");

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
                Console.WriteLine("Summa elementov (stroka " + i + "): " + amount);
                check = false;
            }
            amount = 0;
        }

        Console.ReadKey();
    }
}