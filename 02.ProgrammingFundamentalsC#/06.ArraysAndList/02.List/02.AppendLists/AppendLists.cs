using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class AppendLists
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split('|').ToList();
        numbers.Reverse();
        var result = new List<string>();
        foreach(var item in numbers)
        {
            List<string> list = item.Split(' ').ToList();
            foreach (var num in list)
            {
                result.Add(num);
                result.RemoveAll(x => x == "");
            }
            //foreach (var nums in list)
            //{
            //    if (nums !="")
            //    {
            //        result.Add(nums);
            //    }
            //}
        }
        Console.WriteLine(string.Join(" ", result));
    }
}
