﻿using System.Text;

public class Tesla : ICar, IElectricCar
{
    private string model;
    private string color;
    private int battery;

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public string Model
    {
        get { return this.model; }
        private set { this.model = value; }
    }

    public string Color
    {
        get { return this.color; }
        private set { this.color = value; }
    }

    public int Battery
    {
        get { return this.battery; }
        private set { this.battery = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {GetType().Name} {this.Model} with {this.Battery} Batteries");
        sb.AppendLine(this.Start());
        sb.AppendLine(this.Stop());

        return sb.ToString().Trim();
    }
    

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    
}