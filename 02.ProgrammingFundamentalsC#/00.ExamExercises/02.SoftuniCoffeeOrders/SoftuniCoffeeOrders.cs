using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
class SoftuniCoffeeOrders
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        decimal result = 0;

        for (int i = 0; i < n; i++)
        {
            var price = decimal.Parse(Console.ReadLine());

            string firstDate = Console.ReadLine();

            long capsules = long.Parse(Console.ReadLine());

            DateTime parsedDate = DateTime.ParseExact(firstDate, @"d/M/yyyy", CultureInfo.InvariantCulture);
            var daysOfMonth = DateTime.DaysInMonth(parsedDate.Year, parsedDate.Month);

            decimal orderPrice = daysOfMonth * capsules * price;
            result += orderPrice;

            Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
        }

        Console.WriteLine($"Total: ${result:F2}");
    }
}