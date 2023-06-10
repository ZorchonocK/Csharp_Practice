using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Situation4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            string s_x1 = Console.ReadLine();

            Console.Write("Введите второе число: ");
            string s_x2 = Console.ReadLine();

            Console.Write("Введите третье число: ");
            string s_x3 = Console.ReadLine();

            int x1 = Convert.ToInt32(s_x1);
            int x2 = Convert.ToInt32(s_x2);
            int x3 = Convert.ToInt32(s_x3);

            int max = Math.Max(Math.Max(x1, x2), x3);
            int min = Math.Min(Math.Min(x1, x2), x3);
            int aver = x1 + x2 + x3 - max - min;

            double polsum = (min + max) / 2;

            if (polsum > aver)
            {
                Console.WriteLine("Полсуммы больше");
            }
            else if (polsum == aver)
            {
                Console.WriteLine("Они ровны");
            }
            else
            {
                Console.WriteLine("Полсуммы меньше");
            }
        }
    }
}