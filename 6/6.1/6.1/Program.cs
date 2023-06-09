using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[10];
            int pow = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("A[{0}]:", i);
                A[i] = int.Parse(Console.ReadLine());
                if (A[i] > 0)
                {
                    pow -= A[i];
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Разность: {0}", pow);
            Console.ReadKey();
        }
    }
}
