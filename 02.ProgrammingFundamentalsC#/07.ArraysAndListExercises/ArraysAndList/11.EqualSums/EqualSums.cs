using System;
using System.Collections.Generic;
using System.Linq;

class EqualSums
{
    static void Main()
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        bool notFound = true;

        for (int i = 0; i < list.Count; i++)
        {
            long leftSum = 0;
            long rightSum = 0;
            for (int j = 0; j < i; j++)
            {
                leftSum += list[j];
            }
            for (int j = i+1; j < list.Count; j++)
            {
                rightSum += list[j];
            }
            if (leftSum==rightSum)
            {
                Console.WriteLine(i);
                notFound = false;
            }
        }
        if (notFound)
        {
            Console.WriteLine("no");
        }
    }
}