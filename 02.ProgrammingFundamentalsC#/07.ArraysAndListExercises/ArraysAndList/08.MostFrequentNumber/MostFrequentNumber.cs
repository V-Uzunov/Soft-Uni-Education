using System;
using System.Collections.Generic;
using System.Linq;

class MostFrequentNumber
{
    static void Main()
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        var most = list.GroupBy(i => i).OrderByDescending(grp => grp.Count())
        .Select(grp => grp.Key).First();

        Console.WriteLine(most);

    }
}