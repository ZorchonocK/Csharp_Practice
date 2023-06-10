using System;

public class MyDateTime
{
    int Hour;
    int Minute;
    int Second;

    public void SetHour(int hour)
    {
        Hour = hour;
    }

    public void SetMinute(int minute)
    {
        Minute = minute;
    }

    public void SetSecond(int second)
    {
        Second = second;
    }

    public void SetTime(int hour, int minute, int second)
    {
        SetHour(hour);
        SetMinute(minute);
        SetSecond(second);
    }

    public string ShowTime()
    {
        return "На моих часах время: " + Hour + ":" + Minute + ":" + Second;
    }
}

internal class Program
{

    private static void Main(string[] args)
    {
        var myTime = new MyDateTime();

        string s = "";
        Console.WriteLine("Программа 'Время'");

        try
        {
            while (s != "0")
            {
                Console.WriteLine();
                Console.WriteLine("1. Вывести текущее время");
                Console.WriteLine("2. Ввод времени");
                Console.WriteLine("3. Показать установленное время");
                Console.WriteLine("0. Выход");
                Console.Write("Введите цифру: ");

                s = Console.ReadLine();
                if (s != "1" && s != "2" && s != "3" && s != "0")
                {
                    Console.Write("Неправильный ввод");
                    continue;
                }

                Console.WriteLine();

                int n = int.Parse(s);
                switch (n)
                {
                    case 1:
                        String current_time_str = DateTime.Now.ToString("HH:mm:ss");
                        Console.WriteLine("Текущее время " + current_time_str);
                        break;
                    case 2:
                        Console.WriteLine("Введите новое время в формате hh:mm:ss");
                        var newTime = Console.ReadLine();
                        var newTimeArray = newTime.Split(':');

                        var hour = Int32.Parse(newTimeArray[0]);
                        var minute = Int32.Parse(newTimeArray[1]);
                        var second = Int32.Parse(newTimeArray[2]);

                        if ((hour < 24 || hour >= 0) & (minute <= 59 || minute >= 0) & (second <= 59 || second >= 0))
                        {
                            myTime.SetTime(hour, minute, second);
                            Console.WriteLine("Окей, запомнил");
                        }
                        else
                            throw new Exception("Такого времени не бывает!");

                        break;
                    case 3:
                        Console.WriteLine(myTime.ShowTime());
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}



