using System;

public class ProviderFactory
{
    public IProvider CreateProvider(string id, double energyOutput)
    {
        var type = Type.GetType(id);

        var createInstance = (IProvider) Activator.CreateInstance(type, energyOutput);

        return createInstance;
    }
}