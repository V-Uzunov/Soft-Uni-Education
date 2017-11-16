using System;
using System.Collections.Generic;
using System.Linq;

class BombNumber
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int bomb = input[0];
        int bombPower = input[1];

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == bomb)
            {
                int leftIndex = Math.Max(i - bombPower, 0);
                int rightIndex = Math.Min(i + bombPower, numbers.Count - 1);

                numbers.RemoveRange(i, rightIndex - i);
                numbers.RemoveAt(i);
                numbers.RemoveRange(leftIndex, i - leftIndex);
                i = 0;
            }
        }
        Console.WriteLine(string.Join("", numbers.Sum()));
    }
}