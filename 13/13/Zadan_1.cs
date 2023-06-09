using System;
using _13;


namespace _13
{
    public delegate string MyDelegate(Func<Action<int>, bool, char, string> func);

    public class Zadan_1
    {

        public static void zz()
        { }

        public static void zadanMain_1()
        {
            MyDelegate myDelegate = MyMethod;
            string result = myDelegate(AnotherMethod);
            Console.WriteLine(result);
        }

        public static string MyMethod(Func<Action<int>, bool, char, string> func)
        {
            string result = func(PrintNumber, true, 'A');
            return result;
        }

        public static string AnotherMethod(Action<int> action, bool condition, char character)
        {
            if (condition)
            {
                action(10);
                return character.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static void PrintNumber(int number)
        {
            Console.WriteLine("Number: " + number);
        }
    }
}

