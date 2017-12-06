public abstract class Shape
{
    public abstract double calculatePerimeter();
    public abstract double calculateArea();

    public virtual string Draw()
    {
        return "Drawing ";
    }
}

