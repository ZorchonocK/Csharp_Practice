using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите кол-во меньше которого будет выведено: ");
            int threshold = int.Parse(Console.ReadLine());

            List<Product> products = new List<Product>();

            string[] lines = System.IO.File.ReadAllLines("input.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string type = parts[0];
                double cost = double.Parse(parts[1]);
                string sort = parts[2];
                int quantity = int.Parse(parts[3]);

                Product product = new Product(type, cost, sort, quantity);
                products.Add(product);
            }

            products.Sort();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("output.txt"))
            {
                foreach (Product product in products)
                {
                    if (product.Quantity < threshold)
                    {
                        file.WriteLine(product.ToString());
                    }
                }
            }
            
        }
    }

    class Product : IComparable<Product>
    {
        public string Type { get; set; }
        public double Cost { get; set; }
        public string Sort { get; set; }
        public int Quantity { get; set; }

        public Product(string type, double cost, string sort, int quantity)
        {
            this.Type = type;
            this.Cost = cost;
            this.Sort = sort;
            this.Quantity = quantity;
        }
        public int CompareTo(Product other)
        {
            return this.Quantity.CompareTo(other.Quantity);
        }

        public override string ToString()
        {
            return $"{Type}, {Cost}, {Sort}, {Quantity}";
        }
    }



    class MyClass
    {

        public interface IPolynomial
        {
            bool IsAbove(double x, double y);
            bool IsBelow(double x, double y);
        }

        public class Linear : IPolynomial
        {
            private double k;
            private double b;

            public Linear(double k, double b)
            {
                this.k = k;
                this.b = b;
            }

            public bool IsAbove(double x, double y)
            {
                double value = k * x + b;
                return y > value;
            }

            public bool IsBelow(double x, double y)
            {
                double value = k * x + b;
                return y < value;
            }
        }

        public class Quadratic : IPolynomial
        {
            private double a;
            private double b;
            private double c;

            public Quadratic(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }

            public bool IsAbove(double x, double y)
            {
                double value = a * x * x + b * x + c;
                return y > value;
            }

            public bool IsBelow(double x, double y)
            {
                double value = a * x * x + b * x + c;
                return y < value;
            }
        }

        public static bool IsBetween(IPolynomial lower, IPolynomial upper, double x, double y)
        {
            return lower.IsBelow(x, y) && upper.IsAbove(x, y);
        }

        public static void BuildQuadr()
        {
            Quadratic lower = new Quadratic(-1, 0, 1);
            Quadratic upper = new Quadratic(1, 0, 1);

            bool isBetween = IsBetween(lower, upper, 0, 0);
            Console.WriteLine(isBetween);

            isBetween = IsBetween(lower, upper, 1, 1);
            Console.WriteLine(isBetween);
            BuildQuadr();
        }

        public static void BuildLinear()
        {
            Linear lower = new Linear(-1, 1);
            Linear upper = new Linear(1, 1);

            bool isBetween = IsBetween(lower, upper, 0, 0);
            Console.WriteLine(isBetween);

            isBetween = IsBetween(lower, upper, 0, 2);
            Console.WriteLine(isBetween);
            BuildLinear();
           
        }


    }
}

