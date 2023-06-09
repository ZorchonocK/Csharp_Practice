using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    public class Point
    {
        private double x, y;

        public Point() : this(0, 0) { }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
    }

    public class ColoredPoint : Point
    {
        private string color;

        public ColoredPoint() : this("black") { }
        public ColoredPoint(string color) : this(0, 0, color) { }
        public ColoredPoint(double x, double y, string color) : base(x, y)
        {
            this.color = color;
        }

        public string Color { get { return color; } set { color = value; } }
    }

    public class Line : Point
    {
        private Point start, end;

        public Line() : this(new Point(), new Point()) { }

        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public void Rotate(double angle)
        {
            double x = end.X - start.X;
            double y = end.Y - start.Y;

            end.X = start.X + x * Math.Cos(angle) - y * Math.Sin(angle);
            end.Y = start.Y + x * Math.Sin(angle) + y * Math.Cos(angle);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = new Point[]
            {
    new ColoredPoint(1, 2, "red"),
    new Line(new Point(3, 4), new Point(5, 6)),
    new ColoredPoint(7, 8, "green"),
    new Line(new Point(9, 10), new Point(11, 12))
            };

            foreach (Point point in points)
            {
                Console.WriteLine($"X = {point.X}, Y = {point.Y}");

                if (point is ColoredPoint coloredPoint)
                    Console.WriteLine($"Color = {coloredPoint.Color}");
            }

            foreach (Point point in points)
            {
                if (point is Line line)
                    line.Rotate(Math.PI / 2);
            }

            Console.WriteLine("\nПосле поворота:");
            foreach (Point point in points)
            {
                Console.WriteLine($"X = {point.X}, Y = {point.Y}");

                if (point is ColoredPoint coloredPoint)
                    Console.WriteLine($"Color = {coloredPoint.Color}");
            }
        }
    }


}
