using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Factorial
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        BigInteger factorial = 1;

        for (int i = n; i > 1; i--)
        {
            factorial = BigInteger.Multiply(factorial, i);           
        }
        Console.WriteLine(factorial);
    }
}

