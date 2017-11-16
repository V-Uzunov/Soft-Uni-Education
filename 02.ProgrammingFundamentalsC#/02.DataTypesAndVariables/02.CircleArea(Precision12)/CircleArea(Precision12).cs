using System;

class Program
{
    static void Main()
    {
        var radius = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:f12}", Math.PI*radius*radius);
    }
}

