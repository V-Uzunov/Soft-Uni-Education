using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SumAdjacentEqualNumbers
{
    static void Main()
    {
        var nums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
        for (int i = 1; i < nums.Count; i++)
        {
            if (nums[i-1]==nums[i])
            {
                nums[i - 1] += nums[i];
                nums.RemoveAt(i);
                i-=2;
                if (i<0)
                {
                    i = 0;
                }           
            }            
        }
        Console.WriteLine(string.Join(" ", nums));
    }
}
