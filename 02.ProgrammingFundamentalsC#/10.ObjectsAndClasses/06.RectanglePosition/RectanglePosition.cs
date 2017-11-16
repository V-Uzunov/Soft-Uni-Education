using System;
using System.Collections.Generic;
using System.Linq;

class Rectangle
{
    public int Top { get; set; }
    public int Left { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Right
    {
        get
        {
            return Left + Width;
        }
    }
    public int Bottom
    {
        get
        {
            return Top + Height;
        }
    }
    public bool IsInsside(Rectangle r)
    {
        bool isInside = Top >= r.Top && Bottom <= r.Bottom && Left >= r.Left && Right <= r.Right;
        return isInside;
    }

}
class RectanglePosition
{
    static void Main()
    {
        Rectangle rect1 = ReadRectangle();
        Rectangle rect2 = ReadRectangle();
        if (rect1.IsInsside(rect2))
        {
            Console.WriteLine("Inside");
        }
        else
        {
            Console.WriteLine("Not inside");
        }
    }
    static Rectangle ReadRectangle()
    {
        var rectInfo = Console.ReadLine().Split().Select(int.Parse).ToList();

        Rectangle rect = new Rectangle()
        {
            Left = rectInfo[0],
            Top = rectInfo[1],
            Width = rectInfo[2],
            Height = rectInfo[3]
        };
        return rect;
    }
}