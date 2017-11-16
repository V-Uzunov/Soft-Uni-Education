using System;
using System.Linq;

class LastKNumbersSums
{
    static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        var k = long.Parse(Console.ReadLine());
        long[] arr = new long[n];
        arr[0] = 1;
        for (long i = 1; i < n; i++)
        {
            arr[i] = SumNumbers(arr, i-k, i-1);
        }
        Console.WriteLine(string.Join(" ", arr));
    }

    private static long SumNumbers(long[] arr, long startNumber, long endNumber)
    {
        long sum = 0;
        for (long i = startNumber; i <= endNumber; i++)
        {
            if (i>=0)
            {
                sum += arr[i];
            }
        }
        return sum;
    }
}
