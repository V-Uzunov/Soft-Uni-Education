public class FireMonument : Monument
{
    private double fireAffinity;

    public FireMonument(string name, double fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public double FireAffinity
    {
        get { return this.fireAffinity; }
        protected set { this.fireAffinity = value; }
    }

    public override double GetMonumentBonus()
    {
        return this.FireAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Fire Affinity: {this.FireAffinity}";

    }
}