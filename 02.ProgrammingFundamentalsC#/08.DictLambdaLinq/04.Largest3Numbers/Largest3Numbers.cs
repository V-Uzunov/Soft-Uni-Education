using System;
using System.Collections.Generic;
using System.Linq;

class Largest3Numbers
{
    static void Main()
    {
        var nums = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        var orderNums = nums.OrderByDescending(x => x)
            .Take(3)
            .ToList();

        Console.WriteLine(string.Join(" ", orderNums));
    }
}