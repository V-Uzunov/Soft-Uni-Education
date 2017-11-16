using System;

class ExactSumOfRealNumbers
{
    static void Main()
    {
        var n = decimal.Parse(Console.ReadLine());
        decimal sum = 00m;
        for (int i = 1; i <= n; i++)
        {
            var number = decimal.Parse(Console.ReadLine());
            sum += number;
            
        }
        Console.WriteLine("{0}", sum);
    }
}

