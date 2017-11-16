using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniAirline
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        decimal overAll = 0;
        decimal average = 0;
        List<decimal> avegList = new List<decimal>();

        for (int i = 0; i < n; i++)
        {
            var adultPassengerCount = int.Parse(Console.ReadLine());
            var adultTicketPrice = decimal.Parse(Console.ReadLine());

            var youthPassengerCount = int.Parse(Console.ReadLine());
            var youthTicketPrice = decimal.Parse(Console.ReadLine());

            var fuelPricePerHour = decimal.Parse(Console.ReadLine());
            var fuelConsumptionPerHourd = decimal.Parse(Console.ReadLine());

            var flightDuration = decimal.Parse(Console.ReadLine());

            var income = (adultPassengerCount * adultTicketPrice) + (youthPassengerCount * youthTicketPrice);
            var expenses = fuelConsumptionPerHourd * fuelPricePerHour * flightDuration;
            var profit = income - expenses;
            avegList.Add(profit);

            overAll = avegList.Sum();
            average = avegList.Average();

            if (income >= expenses)
            {
                Console.WriteLine($"You are ahead with {profit:F3}$.");
            }
            else
            {
                Console.WriteLine($"We've got to sell more tickets! We've lost {profit:F3}$.");
            }
        }
        Console.WriteLine($"Overall profit -> {overAll:F3}$.");
        Console.WriteLine($"Average profit -> {average:F3}$.");
    }
}