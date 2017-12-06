public class WaterMonument : Monument
{
    private double waterAffinity;
    public WaterMonument(string name, double waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public double WaterAffinity
    {
        get { return this.waterAffinity; }
        protected set { this.waterAffinity = value; }
    }

    public override double GetMonumentBonus()
    {
        return this.WaterAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Water Affinity: {this.WaterAffinity}";
    }
}