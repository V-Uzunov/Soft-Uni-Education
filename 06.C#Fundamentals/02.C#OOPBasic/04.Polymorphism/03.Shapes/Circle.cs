﻿using System;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get { return this.radius; }
        private set { this.radius = value; }
    }

    public override double calculatePerimeter()
    {
        return (2 * Math.PI) * this.Radius;
    }

    public override double calculateArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}

