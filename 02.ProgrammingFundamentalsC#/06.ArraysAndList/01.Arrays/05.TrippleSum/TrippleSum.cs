using System;
using System.Linq;
class TrippleSum
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var sum = 0;
        bool isNo = true;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                var a = arr[i];
                var b = arr[j];
                sum = a + b;
                if (arr.Contains(sum))
                {
                    Console.WriteLine($"{a} + {b} == {sum}");
                    isNo = false;
                }
                
            }
        }
        if (isNo)
        {
            Console.WriteLine("No");
        }
    }
}
