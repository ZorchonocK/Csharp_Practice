using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания: ");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    // Путь к файлу с текстом
                    string filePath = "C:\\Users\\PC_110822\\Desktop\\практика программирование\\7.docx";
                    string text = File.ReadAllText(filePath);
                    string[] sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");
                    foreach (string sentence in sentences)
                    {
                        if (!sentence.Contains(","))
                        {
                            Console.WriteLine(sentence);
                        }
                        else Console.WriteLine("Тут пусто(");
                    }
                    break;
                case 2:
                    string input = "The number is: hjh42fggf ва3овра 23";
                    MatchCollection match = Regex.Matches(input, @"\d+");

                    if (match == null)
                    {
                        Console.WriteLine("Числа не найдены.");
                    }
                    else
                    {
                        Console.Write("Были найдены числовые значения: ");
                        foreach (var item in match)
                        {
                            Console.Write("{0} ", item);
                        }
                    }
                    break;
                    
                default:
                    Console.WriteLine("Введите задание 1 или 2");
                    break;
            }
        }
    }
}
