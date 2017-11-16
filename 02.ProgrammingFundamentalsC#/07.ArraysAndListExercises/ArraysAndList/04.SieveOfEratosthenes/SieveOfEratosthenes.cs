using System;
using System.Collections.Generic;
using System.Linq;
class SieveOfEratosthenes
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool[] primes = new bool[n + 1];
        for (int num = 0; num <= n; num++)
        {
            primes[num] = true;
        }
        primes[0] = primes[1] = false;

        for (int num = 1; num < primes.Length; num++)
        {
            if (primes[num] == true)
            {
                for (int multiplier = 2; multiplier * num <= n; multiplier++)
                {
                    primes[multiplier * num] = false;
                }
            }
        }
        for (int num = 2; num <= n; num++)
        {
            if (primes[num] == true)
            {
                Console.Write(num + " ");

            }
        }
        Console.WriteLine();
    }
}