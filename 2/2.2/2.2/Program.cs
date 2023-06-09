using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var m = new[] { 1, 2, -120, 3, 4, 5, 0, 6, -1, 2, -7 };
            Console.WriteLine(Min(m));
            Console.ReadKey();
        }
        public static int Min(int[] m, int N = 0)
        {
            return Math.Min(m[N], N == m.Length - 1 ? m[N] : Min(m, N + 1));
        }
    }
}
