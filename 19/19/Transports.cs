using System;
using System.Collections.Generic;
namespace _19
{

    abstract class Vehicle : IComparable<Vehicle>
    {
        public double Price { get; set; }
        public double Speed { get; set; }
        public int Year { get; set; }

        public abstract void Move();

        public int CompareTo(Vehicle other)
        {
            return this.Year.CompareTo(other.Year);
        }
    }

    class Plane : Vehicle
    {
        public double Height { get; set; }

        public override void Move()
        {
            Console.WriteLine("Самолет в полете.");
        }
    }

    class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Машина едет.");
        }
    }

    class Ship : Vehicle
    {
        public int Passengers { get; set; }
        public string Port { get; set; }

        public override void Move()
        {
            Console.WriteLine("Корабль в пути.");
        }
    }
}


