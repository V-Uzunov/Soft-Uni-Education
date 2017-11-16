using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SortNumbers
{
    static void Main()
    {
        var nums = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

        nums.Sort((a, b) => a.CompareTo(b));
        //nums.Sort();
        //nums.Reverse();
        Console.WriteLine(string.Join(" <= ", nums));
    }
}
