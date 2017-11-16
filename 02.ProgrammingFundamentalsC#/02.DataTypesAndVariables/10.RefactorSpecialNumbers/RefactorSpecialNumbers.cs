using System;
using System.Collections.Generic;
using System.Linq;

class RefactorSpecialNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int digit = 0;
        bool isSpecial = false;
        for (int num = 1; num <= n; num++)
        {
            int sum = 0;
            digit = num;
            while (digit > 0)
            {
                sum += digit % 10;
                digit /= 10;
            }
            isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
            Console.WriteLine($"{num} -> {isSpecial}");
        }
    }
}