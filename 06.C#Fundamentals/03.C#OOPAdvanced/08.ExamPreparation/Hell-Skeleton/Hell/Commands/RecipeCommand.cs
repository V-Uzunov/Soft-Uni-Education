using System.Collections.Generic;

public class RecipeCommand : Command
{
    public RecipeCommand(IList<string> args, IHeroManager heroManager) : base(args, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.AddRecipeToHero(this.Args);
    }
}