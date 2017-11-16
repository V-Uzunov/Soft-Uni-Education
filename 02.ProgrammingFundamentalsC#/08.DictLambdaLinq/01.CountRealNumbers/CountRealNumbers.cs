using System;
using System.Collections.Generic;
using System.Linq;

class CountRealNumbers
{
    static void Main()
    {
        var nums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        var counts = new SortedDictionary<double, int>();

        foreach (var num in nums)
        {            
            if (counts.ContainsKey(num))
            {
                counts[num]++;
            }
            else
            {
                counts[num] = 1;
            }
        }
        foreach (var num in counts.Keys)
        {
            Console.WriteLine($"{num} -> {counts[num]}");
        }
    }
}