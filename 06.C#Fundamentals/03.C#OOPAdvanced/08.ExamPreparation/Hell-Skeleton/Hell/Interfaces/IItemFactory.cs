using System.Collections.Generic;

public interface IItemFactory
{
    IItem Create(IList<string> arguments);
}