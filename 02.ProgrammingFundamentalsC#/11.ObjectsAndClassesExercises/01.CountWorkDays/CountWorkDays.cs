using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
class CountWorkDays
{
    static void Main()
    {
        var first = Console.ReadLine();
        var second = Console.ReadLine();

        DateTime startDate = DateTime.ParseExact(first, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(second, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        List<DateTime> holydays = AddHolydays();
        var workingDay = 0;

        for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
        {
            DateTime newDay = new DateTime(2016, currentDate.Month, currentDate.Day);

            if (!holydays.Contains(newDay) && currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                workingDay++;
            }
        }
        Console.WriteLine(workingDay);
    }

    private static List<DateTime> AddHolydays()
    {
        List<DateTime> holydays = new List<DateTime>();
        holydays.Add(new DateTime(2016, 01, 01));
        holydays.Add(new DateTime(2016, 03, 03));
        holydays.Add(new DateTime(2016, 05, 01));
        holydays.Add(new DateTime(2016, 05, 06));
        holydays.Add(new DateTime(2016, 05, 24));
        holydays.Add(new DateTime(2016, 09, 06));
        holydays.Add(new DateTime(2016, 09, 22));
        holydays.Add(new DateTime(2016, 11, 01));
        holydays.Add(new DateTime(2016, 12, 24));
        holydays.Add(new DateTime(2016, 12, 25));
        holydays.Add(new DateTime(2016, 12, 26));
        return holydays;
    }
}