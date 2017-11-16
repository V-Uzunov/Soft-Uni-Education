public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement += (base.EnergyRequirement * 100) / 100;
        this.OreOutput += (base.OreOutput * 200) / 100;
    }
}