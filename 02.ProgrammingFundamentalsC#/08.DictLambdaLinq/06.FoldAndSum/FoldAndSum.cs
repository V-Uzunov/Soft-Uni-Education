using System;
using System.Collections.Generic;
using System.Linq;

class FoldAndSum
{
    static void Main()
    {
        var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = nums.Length / 4;

        var leftRow = nums.Take(k).Reverse().ToArray();
        var rightRow = nums.Reverse().Take(k).ToArray();
        var middleRow = nums.Skip(k).Take(2*k).ToArray();
       
        for (int i = 0; i < leftRow.Length; i++)
        {
            middleRow[i] += leftRow[i];
        }
        for (int i = 0; i < rightRow.Length; i++)
        {
            middleRow[i+k] += rightRow[i];
        }
        Console.WriteLine(string.Join(" ", middleRow));
    }
}