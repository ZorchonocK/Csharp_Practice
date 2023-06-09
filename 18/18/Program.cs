using System;
using System.IO;
using DLL;

class Program {
    static void Main() {
        Console.WriteLine("------------");
        Console.WriteLine(PostalAddress.PostalMain());
        Console.WriteLine("Задание 1");
        Console.WriteLine("------------");

        Console.WriteLine("Задание 2");
        Console.WriteLine(Formula.FormulaMain());
        Console.WriteLine("------------");

        Console.WriteLine("Задание 3");
        Paint.Point point = new Paint.Point(1, 0);
        Paint.Rhomb rhomb = new Paint.Rhomb(point, 2, 3);
        Console.WriteLine(rhomb.IsPointInside(point));
        Console.WriteLine("------------");



        string res1 = Convert.ToString(PostalAddress.PostalMain());
        string res2 = Convert.ToString(Formula.FormulaMain());
        string res3 = Convert.ToString(rhomb.IsPointInside(point));



        string path = "Result.txt";
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.WriteLine(res1);
            writer.WriteLine(res2);
            writer.WriteLine(res3);
        }
    }
}