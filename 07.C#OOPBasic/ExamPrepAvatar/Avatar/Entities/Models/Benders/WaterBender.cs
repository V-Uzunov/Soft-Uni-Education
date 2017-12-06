public class WaterBender : Bender
{
    private double waterClarity;
    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return this.waterClarity; }
        protected set { this.waterClarity = value; }
    }

    public override double GetTotalPower()
    {
        return this.WaterClarity * base.Power;
    }
}