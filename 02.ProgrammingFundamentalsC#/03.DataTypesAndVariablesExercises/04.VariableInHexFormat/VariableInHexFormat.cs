using System;

class VariableInHexFormat
{
    static void Main()
    {
        var num = Console.ReadLine();
        var number = Convert.ToInt32(num, 16);
        Console.WriteLine(number);
    }
}

