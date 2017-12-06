using System.Collections.Generic;

public class HeroCommand : Command
{
    public HeroCommand(IList<string> args, IHeroManager heroManager) : base(args, heroManager)
    {
    }

    public override string Execute()
    {
       return this.HeroManager.AddHero(this.Args);
    }
}