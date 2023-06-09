using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._1
{
    class Program_2
    {
        class Product
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
        }

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

            products.Sort((x, y) => x.Quantity.CompareTo(y.Quantity));

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("output.txt"))
            {
                foreach (Product product in products)
                {
                    if (product.Quantity < threshold)
                    {
                        file.WriteLine($"{product.Type}, {product.Cost}, {product.Sort}, {product.Quantity}");
                    }
                }
            }
        }
    }
}
