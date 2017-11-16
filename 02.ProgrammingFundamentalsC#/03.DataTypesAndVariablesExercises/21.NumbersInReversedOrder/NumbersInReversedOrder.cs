using System;
using System.Linq;

class NumbersInReversedOrder
{
    static void Main()
    {
        var n = Console.ReadLine();

        reversedNumber(n);
    }

    static void reversedNumber(string n)
    {
        Console.WriteLine(string.Join("", n.Reverse()));
        //string str = new String(n.ToString().Reverse().ToArray());
        //Console.WriteLine(str);
    }
}

