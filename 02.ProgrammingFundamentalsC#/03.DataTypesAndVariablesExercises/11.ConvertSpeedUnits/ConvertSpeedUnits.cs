using System;

class ConvertSpeedUnits
{
    static void Main()
    {
        var distance = int.Parse(Console.ReadLine());
        var hours = int.Parse(Console.ReadLine());
        var minutes = int.Parse(Console.ReadLine());
        var seconds = int.Parse(Console.ReadLine());

        var time = (hours * 3600 + minutes * 60 + seconds);

        float metersPerSec = (float)distance / time;
        float kilometersPerHour = ((float)distance / 1000) / ((float)time / 3600);
        float milesPerHour = ((float)distance / 1609) / ((float)time / 3600);
        Console.WriteLine(metersPerSec);
        Console.WriteLine(kilometersPerHour);
        Console.WriteLine(milesPerHour);
    }
}

