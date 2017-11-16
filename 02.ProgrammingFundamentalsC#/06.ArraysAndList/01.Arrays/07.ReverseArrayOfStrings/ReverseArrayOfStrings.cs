using System;
using System.Linq;
class ReverseArrayOfStrings
{
    static void Main()
    {
        var arr = Console.ReadLine().Split(' ').ToArray();

        var reverse = arr.Reverse();
        Console.WriteLine(string.Join(" ", reverse));
    }
}