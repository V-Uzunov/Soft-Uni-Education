using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class RemoveNegativesAndReverse
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var result = new List<int>();

        foreach (var item in numbers)
        {
            if (item>=0)
            {
                result.Add(item);
            }
        }
        result.Reverse();
        if (result.Count>0)
        {
            Console.WriteLine(string.Join(" ", result));
        }
        else
        {
            Console.WriteLine("empty");
        }
    }
}
