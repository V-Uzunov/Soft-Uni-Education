using System.Collections.Generic;

public class ItemCommand : Command
{
    public ItemCommand(IList<string> args, IHeroManager heroManager) : base(args, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.AddItemToHero(this.Args);
    }
}