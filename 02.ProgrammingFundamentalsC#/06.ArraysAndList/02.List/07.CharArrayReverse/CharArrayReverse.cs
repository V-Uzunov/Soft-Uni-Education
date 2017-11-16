using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SquareNumbers
{
    static void Main()
    {
        var str = Console.ReadLine();
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        Console.WriteLine(arr);
    }
}