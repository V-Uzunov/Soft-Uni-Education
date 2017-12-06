using System.Collections.Generic;

public class QuitCommand : Command
{
    public QuitCommand(IList<string> args, IHeroManager heroManager) : base(args, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.PrintAllHeroes();
    }
}