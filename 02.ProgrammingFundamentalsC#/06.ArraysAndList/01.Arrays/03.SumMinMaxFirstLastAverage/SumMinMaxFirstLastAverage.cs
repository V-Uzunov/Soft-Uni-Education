using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SumMinMaxFirstLastAverage
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        SumMinMaxFirstLastAverageMethod(n, arr);
    }

    private static void SumMinMaxFirstLastAverageMethod(int n, int[] arr)
    {
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Sum = {0}", arr.Sum());
        Console.WriteLine("Min = {0}", arr.Min());
        Console.WriteLine("Max = {0}", arr.Max());
        Console.WriteLine("First = {0}", arr.First());
        Console.WriteLine("Last = {0}", arr.Last());
        Console.WriteLine("Average = {0}", arr.Average());
    }
}