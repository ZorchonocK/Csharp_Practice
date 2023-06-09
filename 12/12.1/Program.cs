using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._1
{


    public class PassengerTransporter
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Speed { get; set; }
        public decimal PricePerKilometer { get; set; }

        public void Show()
        {
            Console.WriteLine("Название: {0}", Name);
            Console.WriteLine("Вместимость: {0}", Capacity);
            Console.WriteLine("Скорость: {0}", Speed);
            Console.WriteLine("Цена за километр: {0}", PricePerKilometer);
        }

        public void Get(out string name, out int capacity, out int speed, out decimal pricePerKilometer)
        {
            name = Name;
            capacity = Capacity;
            speed = Speed;
            pricePerKilometer = PricePerKilometer;
        }

        public void Set(string name, int capacity, int speed, decimal pricePerKilometer)
        {
            Name = name;
            Capacity = capacity;
            Speed = speed;
            PricePerKilometer = pricePerKilometer;
        }

        public virtual int CalculateTravelTime(int distance)
        {
            return distance / Speed;
        }

        public virtual decimal CalculateTravelCost(int distance)
        {
            return distance * PricePerKilometer;
        }
    }

    public class Airplane : PassengerTransporter
    {
        public int Altitude { get; set; }
        public string Airline { get; set; }

        public override int CalculateTravelTime(int distance)
        {
            return base.CalculateTravelTime(distance) + 2;
        }

        public decimal CalculateTravelCost(int distance, bool isDiscounted)
        {
            if (isDiscounted)
            {
                return base.CalculateTravelCost(distance) * 0.9m;
            }
            else
            {
                return base.CalculateTravelCost(distance);
            }
        }
    }

    public class Train : PassengerTransporter
    {
        public int NumCars { get; set; }
        public string RailCompany { get; set; }

        public override int CalculateTravelTime(int distance)
        {
            return base.CalculateTravelTime(distance) + (distance / 500);
        }
    }

    public class Car : PassengerTransporter
    {
        public int NumSeats { get; set; }
        public int NumDoors { get; set; }

        public override int CalculateTravelTime(int distance)
        {
            return base.CalculateTravelTime(distance) + (distance / 200);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Airplane airplane = new Airplane
             {
                 Name = "Boeing 747",
                 Capacity = 400,
                 Speed = 800,
                 PricePerKilometer = 0.4m,
                 Altitude = 12000,
                 Airline = "United Airlines"
             };

            Train train = new Train
            {
                Name = "Sapsan",
                Capacity = 300,
                Speed = 400,
                PricePerKilometer = 0.3m,
                NumCars = 10,
                RailCompany = "Russian Railways"
            };

            Car car = new Car
            {
                Name = "Mercedes-Benz S-Class",
                Capacity = 3,
                Speed = 240,
                PricePerKilometer = 0.2m,
                NumSeats = 5,
                NumDoors = 4
            };

            airplane.Show();
            Console.WriteLine("Время передвижения: {0} часов", airplane.CalculateTravelTime(3000));
            Console.WriteLine("Стоимость передвижения: {0:C}", airplane.CalculateTravelCost(3000, true));
            Console.WriteLine();

            train.Show();
            Console.WriteLine("Время передвижения: {0} часов", train.CalculateTravelTime(2000));
            Console.WriteLine("Стоимость передвижения: {0:C}", train.CalculateTravelCost(2000));
            Console.WriteLine();

            car.Show();
            Console.WriteLine("Время передвижения: {0} часов", car.CalculateTravelTime(1000));
            Console.WriteLine("Стоимость передвижения: {0:C}", car.CalculateTravelCost(1000));
        }
    } 





    class ArrayClass
    {
        int[] array ;

        public static bool CompareArrays(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }


        public static bool operator <(ArrayClass array1, ArrayClass array2)
        {
            return !CompareArrays(array1.array, array2.array);
        }

        public static bool operator >(ArrayClass array1, ArrayClass array2)
        {
            return !CompareArrays(array1.array, array2.array);
        }
    }
}