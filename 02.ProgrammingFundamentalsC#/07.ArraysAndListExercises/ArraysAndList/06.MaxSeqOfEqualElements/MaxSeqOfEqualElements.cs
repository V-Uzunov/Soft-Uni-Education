using System;
using System.Collections.Generic;
using System.Linq;
class MaxSequenceOfEqualElements
{
    static void Main()
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        var bestLenght = 0;
        var len = 1;
        var maxLen = 1;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[i] == list[j])
                {
                    len++;
                    if (len > maxLen)
                    {
                        maxLen = len;
                        bestLenght = list[i];
                    }
                }
                else
                {
                    len = 1;
                }
                i++;
                if (maxLen == 1)
                {
                    bestLenght = list[0];
                }
            }
        }
        for (int i = 0; i < maxLen; i++)
        {
            Console.Write(bestLenght + " ");
        }
        Console.WriteLine();
    }
}