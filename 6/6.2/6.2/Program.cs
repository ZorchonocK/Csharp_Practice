using System;
 
namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            int l = int.Parse(Console.ReadLine());
            int[] nums = new int[l];
            for (int i = 0; i < l; i++)
            {
                Console.Write("Введите число номер {0}: ", i + 1);
                nums[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(" ");
            int nummax = nums[0];
            int k = 0;
            int[] nulls = new int[2];
            for (int i = 0; i < l; i++)
            {
                if (nums[i] == 0 && k < 2)
                {
                    nulls[k] = i;
                    k++;
                }
                if (nums[i] > nummax)
                    nummax = nums[i];
            }
            int x = 1;
            Console.WriteLine("Наибольший элемент - {0}", nummax);
            if (k == 2)
            {
                for (int i = nulls[0] + 1; i < nulls[1]; i++)
                    x = x * nums[i];
                if (nulls[0] == nulls[1] - 1)
                    x = 0;
                Console.WriteLine("Произведение элементов между первыми двумя нулями равно {0}", x);
            }
            else
                Console.WriteLine("Для вычисления произведения в массиве не хватает нулей");
            k = 0;
            int[] smun = new int[l];
            for (int i = 0; i < l; i += 2)
            {
                smun[k] = nums[i];
                k++;
            }
            for (int i = 1; i < l; i += 2)
            {
                smun[k] = nums[i];
                k++;
            }
            for (int i = 0; i < l; i++)
                Console.Write(smun[i] + " ");
        }
    }
}
