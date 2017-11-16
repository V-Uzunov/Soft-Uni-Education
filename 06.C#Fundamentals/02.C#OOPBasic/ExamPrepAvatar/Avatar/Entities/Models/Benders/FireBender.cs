public class FireBender : Bender
{
    private double heatAggression;
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression
    {
        get { return this.heatAggression; }
        protected set { this.heatAggression = value; }
    }

    public override double GetTotalPower()
    {
        return this.HeatAggression * base.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Heat Aggression: {this.HeatAggression:f2}";
    }
}