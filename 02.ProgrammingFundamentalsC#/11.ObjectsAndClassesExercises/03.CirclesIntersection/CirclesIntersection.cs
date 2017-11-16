using System;
using System.Collections.Generic;
using System.Linq;

public class Circle
{
    public int Radius { get; set; }
    public Point Center { get; set; }

    public static bool Intersect(Circle firstCircle, Circle secondCirce)
    {
        var deltaX = Math.Abs(firstCircle.Center.X - secondCirce.Center.X);
        var deltaY = Math.Abs(firstCircle.Center.Y - secondCirce.Center.Y);

        double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        var radiusSum = firstCircle.Radius + secondCirce.Radius;

        if (distance<=radiusSum)
        {
            return true;
        }
        return false;
    }

}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}
class CirclesIntersection
{
    static void Main()
    {
        var circleInfo = Console.ReadLine().Split().Select(int.Parse).ToList();
        var secondCircleInfo = Console.ReadLine().Split().Select(int.Parse).ToList();

        Circle firstCirce = new Circle();
        firstCirce.Radius = circleInfo[2];

        Point firstPoint = new Point();
        firstPoint.X = circleInfo[0];
        firstCirce.Center = firstPoint;

        Point secondPoint = new Point
        { X = secondCircleInfo[0]
        , Y = secondCircleInfo[1]
        };

        Circle secondCircle = new Circle
        { Radius = secondCircleInfo[2]
        , Center = secondPoint
        };

        if (Circle.Intersect(firstCirce, secondCircle))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}