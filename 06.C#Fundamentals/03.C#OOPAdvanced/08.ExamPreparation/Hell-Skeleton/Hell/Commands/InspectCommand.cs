using System.Collections.Generic;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> args, IHeroManager heroManager) : base(args, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.Inspect(this.Args);
    }
}