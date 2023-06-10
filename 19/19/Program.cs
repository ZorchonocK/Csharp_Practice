using System;
using System.Collections.Generic;
using _19;

struct Worker
{
    public string Name;
    public string Position;
    public int EmploymentYear;
}

class Program
{
    
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        Plane plane = new Plane();
        plane.Price = 1000000;
        plane.Speed = 900;
        plane.Year = 2020;
        plane.Height = 10000;
        vehicles.Add(plane);

        Car car = new Car();
        car.Price = 50000;
        car.Speed = 200;
        car.Year = 2018;
        vehicles.Add(car);

        Ship ship = new Ship();
        ship.Price = 2000000;
        ship.Speed = 50;
        ship.Year = 2015;
        ship.Passengers = 200;
        ship.Port = "New York";
        vehicles.Add(ship);

        vehicles.Sort();

        foreach (Vehicle vehicle in vehicles)
        {
            if (vehicle is Plane)
            {
                Plane p = (Plane)vehicle;
                Console.WriteLine($"Самолет: Цена = {p.Price}, Скорость = {p.Speed}, Год = {p.Year}, Высота = {p.Height}");
            }
            else if (vehicle is Car)
            {
                Car c = (Car)vehicle;
                Console.WriteLine($"Машина: Цена = {c.Price}, Скорость = {c.Speed}, Год = {c.Year}");
            }
            else if (vehicle is Ship)
            {
                Ship s = (Ship)vehicle;
                Console.WriteLine($"Корабль: Цена = {s.Price}, Скорость = {s.Speed}, Год = {s.Year}, Пасажиров = {s.Passengers}, Порт = {s.Port}");
            }

            vehicle.Move();
        }


        List<Worker> workers = new List<Worker>();

        Console.WriteLine("Введите данные о работниках:");
        for (int i = 0; i < 10; i++)
        {
            Worker worker = new Worker();

            Console.WriteLine($"Работник {i + 1}:");
            Console.Write("Фамилия и инициалы: ");
            worker.Name = Console.ReadLine();
            Console.Write("Должность: ");
            worker.Position = Console.ReadLine();
            Console.Write("Год поступления на работу: ");
            worker.EmploymentYear = int.Parse(Console.ReadLine());

            workers.Add(worker);
        }

        workers.Sort((w1, w2) => w1.Name.CompareTo(w2.Name));

        Console.WriteLine();

        Console.Write("Введите значение стажа работы: ");
        int experience = int.Parse(Console.ReadLine());

        bool hasWorkers = false;

        Console.WriteLine("Работники со стажем работы, превышающим введенное значение:");
        foreach (Worker worker in workers)
        {
            int currentYear = DateTime.Now.Year;
            int yearsOfWork = currentYear - worker.EmploymentYear;

            if (yearsOfWork > experience)
            {
                Console.WriteLine(worker.Name);
                hasWorkers = true;
            }
        }

        if (!hasWorkers)
        {
            Console.WriteLine("Нет работников со стажем работы, превышающим введенное значение.");
        }
    }
}
