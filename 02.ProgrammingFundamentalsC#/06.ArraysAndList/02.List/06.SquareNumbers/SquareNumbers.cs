using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SquareNumbers
{
    static void Main()
    {
        var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var resuult = new List<int>();
        SquareNums(nums, resuult);
        Console.WriteLine(string.Join(" ", resuult));
    }

    static void SquareNums(List<int> nums, List<int> resuult)
    {
        foreach (var num in nums)
        {
            var squareRootNumber = (int)Math.Sqrt(num);
            if (Math.Sqrt(num) == (int)Math.Sqrt(num))
            {
                resuult.Add(num);
                resuult.Sort((a, b) => b.CompareTo(a));
            }
        }
    }
}