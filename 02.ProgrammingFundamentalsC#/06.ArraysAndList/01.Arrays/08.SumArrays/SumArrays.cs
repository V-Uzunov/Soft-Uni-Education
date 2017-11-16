using System;
using System.Linq;
class SumArrays
{
    static void Main()
    {
        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var len = Math.Max(arr.Length, arr2.Length);

        var result = new int[len];

        for (int i = 0; i < len; i++)
        {
            result[i] = arr[i % arr.Length] + arr2[i % arr2.Length];
        }
        Console.WriteLine(string.Join(" ", result));       
    }
}
