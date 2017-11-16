using System;
using System.Collections.Generic;
using System.Linq;

class MaxSeqOfEqualElem
{
    static void Main()
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        var bestLeng = 0;
        var maxCount = 1;
        var counter = 1;

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i+1; j < list.Count; j++)
            {
                if (list[i]==list[j])
                {
                    counter++;
                    if (counter>maxCount)
                    {
                        maxCount = counter;
                        bestLeng = list[i];
                    }
                }
                else
                {
                    counter = 1;
                }
                i++;
                if (maxCount == 1)
                {
                    bestLeng = list[0];
                }
            }
        }
        for (int i = 0; i < maxCount; i++)
        {
            Console.Write(bestLeng+" ");
        }
        Console.WriteLine();
    }
}