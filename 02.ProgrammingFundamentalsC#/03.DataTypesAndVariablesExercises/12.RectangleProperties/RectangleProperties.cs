using System;

class RectangleProperties
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        var perimeter =2*(width+height);
        var area = width * height;
        var diagonal = Math.Sqrt(width * width + height * height);
        Console.WriteLine("{0}\n{1}\n{2}", perimeter, area, diagonal);
    }
}

