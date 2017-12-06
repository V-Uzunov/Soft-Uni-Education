public class EarthMonument : Monument
{
    private double earthAffinity;
    public EarthMonument(string name, double earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public double EarthAffinity
    {
        get { return this.earthAffinity; }
        protected set { this.earthAffinity = value; }
    }

    public override double GetMonumentBonus()
    {
        return this.EarthAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Earth Affinity: {this.EarthAffinity}";
    }
}