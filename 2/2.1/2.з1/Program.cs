using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.з1
{
    internal class Program
    {
        
        static double Primer1(double x = 1.426, double y = -0.823, double z = 2.724)
        {
            double a = (Math.Sqrt(x) + 2 * Math.Cos(x + Math.PI / 6)) / (2.4 - Math.Pow(Math.Sin(x + y), 2));
            return a;
        }

        static void Primer2(double x = 1.426, double y = -0.823, double z = 2.724)
        {
            double b = (1.8 + (Math.Exp(-y * z)) / 1 + Math.Tan(x + y + z));
            Console.WriteLine(b);
         
        
        }
        private static void Main(string[] args)
        {
            Console.WriteLine(Primer1());
            Primer2();
        }

    }
}