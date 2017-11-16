using System;

class IntegerToHexAndBinary
{
    static void Main()
    {
        int num  = int.Parse(Console.ReadLine());
        string hexValue = num.ToString("X");
        string binary = Convert.ToString(num, 2);
        Console.WriteLine("{0}\n{1}", hexValue, binary);
    }
}

