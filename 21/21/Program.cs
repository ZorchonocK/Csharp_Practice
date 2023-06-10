using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class WarcraftUnit
{
    private int unitId;
    private int goldPerPortion;
    private int totalGoldMined;
    private int mineCapacity;
    private Random random;

    public WarcraftUnit(int id, int goldPerPortion, int mineCapacity)
    {
        unitId = id;
        this.goldPerPortion = goldPerPortion;
        totalGoldMined = 0;
        this.mineCapacity = mineCapacity;
        random = new Random();
    }

    public async Task StartMiningAsync()
    {
        Console.WriteLine($"Unit {unitId} начал добычу.");

        while (totalGoldMined < mineCapacity)
        {
            await MineGoldAsync();
        }

        Console.WriteLine($"Unit {unitId} закончил добычу. Всего золота накопано: {totalGoldMined}");
    }

    private async Task MineGoldAsync()
    {
        int miningTime = random.Next(1000, 5000);
        await Task.Delay(miningTime);

        int goldMined = Math.Min(goldPerPortion, mineCapacity - totalGoldMined);
        totalGoldMined += goldMined;

        Console.WriteLine($"Unit {unitId} накопал {goldMined} золота. Всего золота накопано: {totalGoldMined}");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        int numUnits = 5;
        int goldPerPortion = 50;
        int mineCapacity = 1000;

        List<Task> miningTasks = new List<Task>();

        for (int i = 1; i <= numUnits; i++)
        {
            var unit = new WarcraftUnit(i, goldPerPortion, mineCapacity);
            miningTasks.Add(unit.StartMiningAsync());
        }

        await Task.WhenAll(miningTasks);

        Console.WriteLine("Работяги отпахали.");
    }
}
