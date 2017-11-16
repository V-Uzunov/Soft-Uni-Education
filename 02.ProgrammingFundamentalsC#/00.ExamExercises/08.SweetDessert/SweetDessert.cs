using System;
using System.Collections.Generic;
using System.Linq;

class SweetDessert
{
    static void Main()
    {
        var cash = decimal.Parse(Console.ReadLine());
        var numberOfGuest = long.Parse(Console.ReadLine());
        var bannana = decimal.Parse(Console.ReadLine());
        var egg = decimal.Parse(Console.ReadLine());
        var baries = decimal.Parse(Console.ReadLine());

        var sets = (int)(Math.Ceiling(numberOfGuest / 6.0));

        decimal price = sets * (2 * bannana) + sets * (4 * egg) + sets * ((decimal)0.2 * baries);
        decimal fullPrice = price - cash;

        if (price<=cash)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {price:F2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivancho will have to withdraw money - he will need {fullPrice:F2}lv more.");
        }

    }
}