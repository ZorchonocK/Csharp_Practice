using System;
using System.Collections.Generic;
using System.Linq;

class Program_1
{
    enum Property
    {
        CareerGrowthOpportunities = 10,
        GoodWorkLifeBalance = 5,
        CompetitiveSalary = 8,
        LimitedVacationTime = -10
    }

    struct Finn
    {
        public string Name;
        public List<Property> Properties;
    }

    static void Main(string[] args)
    {
        List<Finn> finns = new List<Finn>
    {
        new Finn
        {
            Name = "A",
            Properties = new List<Property>
            {
                Property.CareerGrowthOpportunities,
                Property.GoodWorkLifeBalance,
                Property.CompetitiveSalary,
                Property.LimitedVacationTime
            }
        },
        new Finn
        {
            Name = "B",
            Properties = new List<Property>
            {
                Property.CareerGrowthOpportunities,
                Property.GoodWorkLifeBalance
            }
        },
        new Finn
        {
            Name = "C",
            Properties = new List<Property>
            {
                Property.GoodWorkLifeBalance,
                Property.CompetitiveSalary
            }
        }
    };

        List<Finn> sortedFinns = finns.OrderByDescending(f => f.Properties.Sum(p => (int)p)).ToList();

        foreach (Finn f in sortedFinns)
        {
            Console.WriteLine("Компания <<{0}>>", f.Name);
        }
    }
}

