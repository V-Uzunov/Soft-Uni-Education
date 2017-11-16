using System;

public class HarvesterFactory
{
    public IHarvester CreateHarvester(string id, double oreOutput, double energyRequirement)
    {
        var type = Type.GetType(id);

        IHarvester createInstance = (IHarvester) Activator.CreateInstance(type, oreOutput, energyRequirement);

        return createInstance;
    }

    public IHarvester CreateHarvesterSonic(string id, double oreOutput, double energyRequirement, int sonicFactor)
    {
        var type = Type.GetType(id);

        IHarvester createInstance = (IHarvester)Activator.CreateInstance(type, oreOutput, energyRequirement, sonicFactor);

        return createInstance;
    }
}