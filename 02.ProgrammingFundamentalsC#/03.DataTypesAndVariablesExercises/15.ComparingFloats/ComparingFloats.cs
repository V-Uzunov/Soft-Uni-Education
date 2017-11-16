using System;

class ComparingFloats
{
    static void Main()
    {
        var a = double.Parse(Console.ReadLine());
        var b = double.Parse(Console.ReadLine());

        var eps = 0.000001;

        var difference =Math.Abs(a - b);

        if (difference>=eps)
        {
            Console.WriteLine("False");
        }
        else
        {
            Console.WriteLine("True");
        }
    }
}