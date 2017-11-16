using System;
using System.Collections.Generic;
using System.Linq;

class Numbers
{
    static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToList();

        var averageNum = input.Average();

        List<double> result = new List<double>();

        bool isFound = true;

        for (int i = 0; i < input.Count; i++)
        {
            if (input[i] > averageNum)
            {
                result.Add(input[i]);
                isFound = false;
            }
        }
        if (isFound)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(string.Join(" ", result.OrderByDescending(x =>x).Take(5)));
        }
    }
}