using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private IList<IBender> benders;
    private IList<IMonument> monuments;

    public Nation()
    {
        this.benders = new List<IBender>();
        this.monuments = new List<IMonument>();
    }

    public void AddBender(IBender bender) => this.benders.Add(bender);

    public void AddMonument(IMonument monument) => this.monuments.Add(monument);

    public double GetTotalPoints()
    {
        var power = this.benders.Sum(b => b.GetTotalPower());
        var bonus = this.monuments.Sum(m => m.GetMonumentBonus());

        return power + power / 100 * bonus;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (benders.Count > 0)
        {
            sb.AppendLine($"Benders:");
            sb.AppendLine(string.Join(Environment.NewLine, benders));
        }
        else
        {
            sb.AppendLine("Benders: None");
        }

        if (monuments.Count > 0)
        {
            sb.AppendLine($"Monuments:");
            sb.AppendLine(string.Join(Environment.NewLine, monuments));
        }
        else
        {
            sb.AppendLine("Monuments: None");
        }

        return sb.ToString().Trim();
    }

    public void KillYourself()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}