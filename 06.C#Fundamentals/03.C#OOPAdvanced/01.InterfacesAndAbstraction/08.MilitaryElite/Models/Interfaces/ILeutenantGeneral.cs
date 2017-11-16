using System.Collections.Generic;

namespace _8.MilitaryElite.Models
{
    public interface ILeutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; }
    }
}