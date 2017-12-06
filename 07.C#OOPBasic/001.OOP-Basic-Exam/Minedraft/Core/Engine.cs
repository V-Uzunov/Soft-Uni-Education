using System;
using System.Linq;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IDraftManager draftManager;
    private bool IsRunning;
    public Engine(IReader reader, IWriter writer, IDraftManager draftManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.draftManager = draftManager;
        this.IsRunning = true;
    }

    public void Run()
    {
        while (IsRunning)
        {
            var tokens = reader.Read().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = tokens[0];
            tokens.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    writer.Write(draftManager.RegisterHarvester(tokens));
                    break;
                case "RegisterProvider":
                    writer.Write(draftManager.RegisterProvider(tokens));
                    break;
                case "Day":
                    writer.Write(draftManager.Day());
                    break;
                case "Mode":
                    writer.Write(draftManager.Mode(tokens));
                    break;
                case "Check":
                    writer.Write(draftManager.Check(tokens));
                    break;
                case "Shutdown":
                    writer.Write(draftManager.ShutDown());
                    IsRunning = false;
                    break;
            }
        }
    }
}