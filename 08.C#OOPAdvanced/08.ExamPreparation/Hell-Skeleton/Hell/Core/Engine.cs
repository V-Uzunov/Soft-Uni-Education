using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    public const string TerminatingCommand = "Quit";

    private IInputReader reader;
    private IOutputWriter writer;

    private ICommandInterpreter commandInterpreter;

    public Engine(IInputReader reader, IOutputWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }
    private IList<string> parseInput(string input)
    {
        return input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
    public void Run()
    {
        string inputLine;

        while ((inputLine = this.reader.ReadLine()) != TerminatingCommand)
        {
            var cmdArgs = this.parseInput(inputLine);

            var result = this.commandInterpreter.InterpretCommand(cmdArgs);

            this.writer.WriteLine(result);
        }
    }
}