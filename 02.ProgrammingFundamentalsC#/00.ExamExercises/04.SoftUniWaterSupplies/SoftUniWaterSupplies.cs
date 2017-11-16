using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniWaterSupplies
{
    static void Main()
    {
        var water = int.Parse(Console.ReadLine());
        var bottles = Console.ReadLine().Split().Select(double.Parse).ToList();
        var capacityOfBottles = int.Parse(Console.ReadLine());
        double result = 0;
        var bottleLeft = 0;
        if (water % 2 == 0)
        {
            for (int i = 0; i < bottles.Count; i++)
            {
                result += capacityOfBottles - bottles[i];
            }
            if (water > result)
            {
                Console.WriteLine("Enought water!");
                Console.WriteLine($"Water left {result}l.");
            }
            else
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {bottleLeft}");
                Console.WriteLine($"With indexes: {0}");
                Console.WriteLine($"We need {result-water} more liters!");
            }
        }
        else
        {
            for (int i = bottles.Count - 1; i >= 0; i--)
            {
                result += capacityOfBottles - bottles[i];
            }
            if (water > result)
            {
                Console.WriteLine("Enought water!");
                Console.WriteLine($"Water left {result}l.");
            }
            else
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {bottleLeft}");
                Console.WriteLine($"With indexes: {0}");
                Console.WriteLine($"We need {result-water} more liters!");
            }
        }
    }
}