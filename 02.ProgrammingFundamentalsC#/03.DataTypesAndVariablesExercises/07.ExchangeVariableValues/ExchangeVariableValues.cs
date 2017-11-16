using System;

class ExchangeVariableValues
{
    static void Main()
    {
        var a = 5;
        var b = 10;
        var c = a;
        Console.WriteLine("Before:");
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
        a = b;
        b = c;
        Console.WriteLine("After:");
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
    }
}

