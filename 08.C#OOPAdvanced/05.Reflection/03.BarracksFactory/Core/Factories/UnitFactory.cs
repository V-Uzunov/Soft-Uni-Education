using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var getType = Assembly.GetExecutingAssembly().DefinedTypes.First(x => x.Name == unitType);
            var unit = (IUnit)Activator.CreateInstance(getType);
            return unit;
        }
    }
}
