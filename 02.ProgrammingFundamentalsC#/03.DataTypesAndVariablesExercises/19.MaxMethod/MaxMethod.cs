using System;

class MaxMethod
{
    static void Main()
    {
        var a = int.Parse(Console.ReadLine());
        var b = int.Parse(Console.ReadLine());
        var c = int.Parse(Console.ReadLine());

        getMax(a, b, c);
    }

    private static void getMax(int a, int b, int c)
    {
        int result = Math.Max(Math.Max(a, b), c);
        Console.WriteLine(result);
    }
   // private static void getMax(int a, int b, int c)
   // {
   //     if (a>=b && a>=c)
   //     {
   //         Console.WriteLine(a);
   //     }
   //     else if (b>=a && b>=c)
   //     {
   //         Console.WriteLine(b);
   //     }
   //     else if (c >= a && c >= b)
   //     {
   //         Console.WriteLine(c);
   //     }
   // }
}

