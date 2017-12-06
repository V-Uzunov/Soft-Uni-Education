using System.Collections;
using System.Collections.Generic;

namespace _8.MilitaryElite.Models.Interfaces
{
    public interface IIngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}
