using System;
using System.Linq;
class ExtractMiddleElements
{
    static void Main()
    {
        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var result = ExtractMiddleElementMethod(arr);
        Console.WriteLine("{ "+string.Join(", ", result)+" }");
    }

    static int[] ExtractMiddleElementMethod(int[]arr)
    {
        var len = arr.Length;
        if (len == 1)
        {
            return arr;
        }
        if (len % 2==0)
        {
            return new int[] { arr[len / 2-1], arr[len / 2] };
        }
        else
        {
            return new int[] { arr[len / 2 - 1], arr[len / 2], arr[len / 2 + 1] };
        }
    }
}