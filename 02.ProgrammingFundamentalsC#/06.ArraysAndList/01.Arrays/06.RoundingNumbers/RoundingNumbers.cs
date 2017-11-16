using System;
using System.Linq;
class RoundingNumbers
{
    static void Main()
    {
        var arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

        foreach (var number in arr)
        {
            Console.WriteLine("{0} => {1}", number, Math.Round(number, MidpointRounding.AwayFromZero));
        }
    }
}

