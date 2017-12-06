using System;
using System.Linq;

public class Engine : IEngine
{
    private INationsBuilder nationsBuilder;
    private IWriter writer;
    private IReader reader;

    public Engine(INationsBuilder nationsBuilder, IWriter writer, IReader reader)
    {
        this.nationsBuilder = nationsBuilder;
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        bool isRunning = true; 
        while (isRunning)
        {
            var tokents = reader.Read().Split(' ').ToList();
            var command = tokents[0];
            tokents.RemoveAt(0);

            switch (command)
            {
                case "Bender":
                    nationsBuilder.AssignBender(tokents);
                    break;
                case "Monument":
                    nationsBuilder.AssignMonument(tokents);
                    break;
                case "Status":
                    writer.Write(nationsBuilder.GetStatus(tokents[0]).ToString());
                    break;
                case "War":
                    nationsBuilder.IssueWar(tokents[0]);
                    break;
                case "Quit":
                    writer.Write(nationsBuilder.GetWarsRecord().ToString());
                    isRunning = false;
                    break;
            }
        }
    }
}