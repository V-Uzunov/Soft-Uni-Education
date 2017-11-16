using System;

public class Startup
{
    public static void Main()
    {
        var circle = new Circle(5);
        Console.WriteLine(circle.calculateArea());
        Console.WriteLine(circle.calculatePerimeter());
        Console.WriteLine(circle.Draw());
    }
}

