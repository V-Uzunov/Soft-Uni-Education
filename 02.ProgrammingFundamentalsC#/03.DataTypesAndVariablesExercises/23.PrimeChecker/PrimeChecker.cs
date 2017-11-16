using System;

class PrimeChecker
{
    static void Main()
    {
        var n = double.Parse(Console.ReadLine());
        bool isPrime = true;
        Prime(n, isPrime);
    }

    static void Prime(double n, bool isPrime)
    {
        if (n<=1)
        {
            isPrime = false;
        }
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n%i==0)
            {
                isPrime = false;
            }
        }
        Console.WriteLine(isPrime);
    }
}