using System.Collections.Generic;

public abstract class Command : IExecutable
{
    private IList<string> args;
    private IHeroManager heroManager;
    
    public Command(IList<string> args, IHeroManager heroManager)
    {
        this.args = args;
        this.HeroManager = heroManager;
    }

    public IList<string> Args
    {
        get { return this.args; }
        protected set { this.args = value; }
    }

    public IHeroManager HeroManager
    {
        get { return this.heroManager; }
        protected set { this.heroManager = value; }
    }

    public abstract string Execute();
}