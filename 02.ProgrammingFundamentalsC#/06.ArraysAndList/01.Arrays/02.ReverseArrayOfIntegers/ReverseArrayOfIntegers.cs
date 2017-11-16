using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseArrayOfIntegers
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        for (int i = n-1; i >=0; i--)
        {
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();
    }
}
