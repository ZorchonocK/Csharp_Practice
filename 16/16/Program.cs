using System;
using UnrolledListLibrary;

class Program
{
    static void Main(string[] args)
    {
        UnrolledList<int> list = new UnrolledList<int>(3);

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);

        Console.WriteLine(list.Get(0));  // Output: 1
        Console.WriteLine(list.Get(2));  // Output: 3
        Console.WriteLine(list.Get(4));  // Output: 5
    }
}
