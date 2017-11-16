using System;
using System.Collections.Generic;
using System.Linq;

class RotateAndSum
{
    static void Main()
    {
        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var rotation = int.Parse(Console.ReadLine());

        var sum = new int[arr.Length];

        var result = SumOfElements(arr, sum, rotation);
        Console.WriteLine(string.Join(" ", result));
    }

    private static int[] SumOfElements(int[] arr, int[] sum, int rotation)
    {
        for (int i = 0; i < rotation; i++)
        {
            int lastElement = arr[arr.Length - 1];

            Array.Copy(arr, 0, arr, 1, arr.Length - 1);
            arr[0] = lastElement;

            for (int k = 0; k < arr.Length; k++)
            {
                sum[k] += arr[k];
            }
        }
        return sum;
    }
}