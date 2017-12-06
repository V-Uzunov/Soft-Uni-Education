public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.sonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        protected set { this.sonicFactor = value; }
    }
}