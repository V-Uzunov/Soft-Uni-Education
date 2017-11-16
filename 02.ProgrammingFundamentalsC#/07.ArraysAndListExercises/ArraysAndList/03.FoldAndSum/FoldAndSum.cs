using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var k = arr.Length / 4;
        var firstRow = new int[k];
        var lastRow = new int[k];
        var sum = new int[arr.Length / 2];

        for (int i = 0; i < k; i++)
        {
            firstRow[i] = arr[(arr.Length / 4) - 1 - i];
            lastRow[i] = arr[arr.Length - 1 - i];
        }

        for (int i = 0; i < arr.Length / 4; i++)
        {
            sum[i] = firstRow[i] + arr[(arr.Length / 4) + i];
            sum[arr.Length / 4 + i] = lastRow[i] + arr[arr.Length / 2 + i];
        }
        Console.WriteLine(string.Join(" ", sum));
    }
}