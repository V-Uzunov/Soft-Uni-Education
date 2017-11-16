public class AirMonument : Monument
{
    private double airAffinity;
    public AirMonument(string name, double airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public double AirAffinity
    {
        get { return this.airAffinity; }
        protected set { this.airAffinity = value; }
    }

    public override double GetMonumentBonus()
    {
        return this.AirAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Air Affinity: {this.AirAffinity}";
    }
}