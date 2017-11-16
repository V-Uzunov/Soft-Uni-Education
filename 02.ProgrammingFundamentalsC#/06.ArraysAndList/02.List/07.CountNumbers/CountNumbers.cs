using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var nums = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x =>x).ToList();
        var counts = 1;
        var previousElement = nums[0];
        for (int i = 1; i < nums.Count; i++)
        {
            if (previousElement==nums[i])
            {
                counts++;
            }
            else
            {
                Console.WriteLine($"{previousElement} -> {counts}");
                previousElement = nums[i];
                counts = 1;
            }
        }
        Console.WriteLine($"{previousElement} -> {counts}");
    }
}

