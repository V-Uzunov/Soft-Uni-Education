using System;
using System.Linq;
class CondenseArrayToNumber
{
    static void Main()
    {
        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        while (arr.Length > 1)
        {
            var condense = new int[arr.Length - 1];
            for (int r = 0; r < arr.Length-1; r++)
            {
                for (int i = 0; i < arr.Length-1; i++)
                {
                    condense[i] = arr[i] + arr[i + 1];
                }
            }
            arr = condense;
        }
        Console.WriteLine(arr[0]);
    }
}