using System.Collections.Generic;

public interface INationsBuilder
{
    void AssignBender(IList<string> benderArgs);
    void AssignMonument(IList<string> monumentArgs);
    string GetStatus(string nationsType);
    void IssueWar(string nationsType);
    string GetWarsRecord();
}