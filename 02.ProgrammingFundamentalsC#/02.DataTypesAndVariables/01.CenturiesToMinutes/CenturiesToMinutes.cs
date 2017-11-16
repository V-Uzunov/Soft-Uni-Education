using System;

class CenturiesToMinutes
{
    static void Main()
    {
        byte centuries = byte.Parse(Console.ReadLine());

        int year = centuries * 100;
        int days =(int)(year * 365.2422);
        int hours = days * 24;
        long minutes = hours * 60;
        Console.WriteLine($"{centuries} centuries = {year} years = {days} days = {hours} hours = {minutes} minutes");
    }
}

