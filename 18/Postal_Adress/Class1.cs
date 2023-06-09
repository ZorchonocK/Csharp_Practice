using System;
using System.Runtime.CompilerServices;
namespace DLL
{
    public class PostalAddress
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public static string PostalMain()
        {
            PostalAddress postalAddress = new PostalAddress("123 Main St", "City", "State", "12345", "Country");
            return postalAddress.ToString();
        }

        public PostalAddress(string street, string city, string state, string postalCode, string country)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
        }

        public override string ToString()
        {
            DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 5);
            defaultInterpolatedStringHandler.AppendFormatted(Street);
            defaultInterpolatedStringHandler.AppendLiteral(", ");
            defaultInterpolatedStringHandler.AppendFormatted(City);
            defaultInterpolatedStringHandler.AppendLiteral(", ");
            defaultInterpolatedStringHandler.AppendFormatted(State);
            defaultInterpolatedStringHandler.AppendLiteral(", ");
            defaultInterpolatedStringHandler.AppendFormatted(PostalCode);
            defaultInterpolatedStringHandler.AppendLiteral(", ");
            defaultInterpolatedStringHandler.AppendFormatted(Country);
            return defaultInterpolatedStringHandler.ToStringAndClear();
        }
    }

    public class Paint
    {
        

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }


        public class Rhomb
        {
            public Point Center { get; set; }
            public double Diagonal1 { get; set; }
            public double Diagonal2 { get; set; }

            public Rhomb(Point center, double diagonal1, double diagonal2)
            {
                Center = center;
                Diagonal1 = diagonal1;
                Diagonal2 = diagonal2;
            }

            public bool IsPointInside(Point point)
            {
                double distanceX = Math.Abs(point.X - Center.X);
                double distanceY = Math.Abs(point.Y - Center.Y);
                double halfDiagonal1 = Diagonal1 / 2;
                double halfDiagonal2 = Diagonal2 / 2;

                return (distanceX / halfDiagonal1) + (distanceY / halfDiagonal2) <= 1;
            }
        }
    }

    public class Formula
    {
        public static string FormulaMain()
        {
            Formula myFunction = new Formula();

            double result = myFunction.CalculateFunction(1.0, 1.0, 1.0);

            return "Результат функции: " + result;
        }

        public double CalculateFunction(double x, double y, double z)
        {
            double result = Convert.ToDouble(Math.Sqrt(10.0 * (Math.Pow(x, 1.0 / 3.0) + Math.Pow(x, y + 2.0))) *  (Math.Pow(Math.Asin(z), 2)) - Math.Abs(x - y));

            return result;
        }

    }

}
