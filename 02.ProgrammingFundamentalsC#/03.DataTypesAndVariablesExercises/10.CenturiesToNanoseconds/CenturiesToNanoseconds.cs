using System;
class CenturiesToNanoseconds
{
    static void Main()
    {
        byte centuries = byte.Parse(Console.ReadLine());
        int years =(int)(centuries * 100);
        int days = (int)(years * 365.2422);
        int hours =(int)(days*24);
        long minutes =hours * 60;
        long seconds = minutes*60;
        long milliseconds = seconds* 1000;
        long microseconds = milliseconds*1000;
        decimal nanoseconds =(decimal)microseconds*1000;
        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
}

