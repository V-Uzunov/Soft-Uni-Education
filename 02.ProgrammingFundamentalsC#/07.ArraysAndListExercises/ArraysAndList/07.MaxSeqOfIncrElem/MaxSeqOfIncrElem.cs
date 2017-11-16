using System;
using System.Collections.Generic;
using System.Linq;

class MaxSeqOfIncrElem
{
    static void Main()
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();

        var startLenght = 0;
        var count = 1;
        var maxCount = 1;

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] > list[i - 1])
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > maxCount)
            {
                maxCount = count;
                startLenght = i + 1 - maxCount;
            }
        }
        for (int i = startLenght; i < maxCount + startLenght; i++)
        {
            Console.Write("{0} ", list[i]);
        }
        Console.WriteLine();
    }
}