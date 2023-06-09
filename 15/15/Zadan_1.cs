using System;
using System.Threading;
namespace _15
{
    public class Zadan_1
    {
        public static void Start()
        {
            Thread th = new Thread(ZadanMain_1);
            th.Start();
            th.Join();
        }

        public static void ZadanMain_1()
        {
            double x = GetRandomComponent();
            double y = GetRandomComponent();
            double z = GetRandomComponent();

            Vector vector = new Vector(x, y, z);

            double module = Math.Abs(x + y + z);

            Console.WriteLine($"Случайный вектор: ({x}, {y}, {z})");
            Console.WriteLine($"Модуль вектора: {module}");
        }

        static double GetRandomComponent()
        {
            return (new Random().NextDouble() * 2) - 1;
        }

    }

    class Vector
    {
        private double x;
        private double y;
        private double z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}

