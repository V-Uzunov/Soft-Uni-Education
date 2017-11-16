using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
class DayOfWeek
{
    static void Main()
    {
        var date = Console.ReadLine();

        DateTime dayOfWeek = DateTime.ParseExact(date, "d-M-yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine(dayOfWeek.DayOfWeek);
    }
}