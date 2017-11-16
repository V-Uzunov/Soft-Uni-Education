using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuff = "Command";

    private IHeroManager heroManager;

    public CommandInterpreter(IHeroManager heroManager)
    {
        this.heroManager = heroManager;
    }

    public string InterpretCommand(IList<string> args)
    {
        IExecutable command = this.ParseCommand(args);
        return command.Execute();
    }

    private IExecutable ParseCommand(IList<string> args)
    {
        var commandName = args[0] + CommandSuff;
        args = args.Skip(1).ToList();

        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName);
        if (type == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        var data = new object[]
        {
            args
            ,this.heroManager
        };

        var currentInstance = (IExecutable)Activator.CreateInstance(type, data);

        return currentInstance;
    }
}