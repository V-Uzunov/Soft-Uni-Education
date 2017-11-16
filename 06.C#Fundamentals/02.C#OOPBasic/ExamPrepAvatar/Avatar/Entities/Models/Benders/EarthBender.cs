public class EarthBender : Bender
{
    private double groundSaturation;
    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return this.groundSaturation; }
        protected set { this.groundSaturation = value; }
    }

    public override double GetTotalPower()
    {
        return this.GroundSaturation * base.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Ground Saturation: {this.GroundSaturation:f2}";
    }
}