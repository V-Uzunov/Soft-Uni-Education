using System;
using System.Collections.Generic;
using System.Linq;

class PairsByDifference
{
    static void Main()
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        var diff = int.Parse(Console.ReadLine());
        var count = 0;

        foreach (var num in list)
        {
            foreach (var nums in list)
            {
                if (num-nums==diff)
                {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
          
    }
}