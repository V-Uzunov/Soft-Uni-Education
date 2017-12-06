using System.Collections.Generic;

public interface IDraftManager
{
    string RegisterHarvester(IList<string> arguments);
    string RegisterProvider(IList<string> arguments);
    string Day();
    string Mode(IList<string> arguments);
    string Check(IList<string> arguments);
    string ShutDown();
}