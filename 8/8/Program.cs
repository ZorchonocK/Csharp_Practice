using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace _8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Введите строку для проверки: ");
            string str = Console.ReadLine();

            Regex regex = new Regex(@"^[+-]?[0-9]*\.?[0-9]+([eE][+-]?[0-9]+)?$");
            Match match = regex.Match(str);

            if (match.Success)
            {
                Console.WriteLine("Строка соответствует");
            }
            else
            {
                Console.WriteLine("Не соответствует");
            }
        }
    }
}
