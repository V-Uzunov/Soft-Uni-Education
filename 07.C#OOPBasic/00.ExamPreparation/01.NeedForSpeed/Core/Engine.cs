using System;
using System.Diagnostics;

public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.manager = new CarManager();
    }

    public void Run()
    {
        string input;

        while ((input=Console.ReadLine()) != "Cops Are Here")
        {
            var cmdArgs = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            ExecuteCommand(cmdArgs);
        }
    }

    private void ExecuteCommand(string[] cmdArg)
    {
        int id;
        string type;
        string brand;
        string model;
        int year;
        int horsePower;
        int acceleration;
        int suspension;
        int durability;
        int carId;
        int raceId;
        int length;
        string route;
        int prizePool;
        switch (cmdArg[0])
        {
            case "register":
                id = int.Parse(cmdArg[1]);
                type = cmdArg[2];
                brand = cmdArg[3];
                model = cmdArg[4];
                year =int.Parse(cmdArg[5]);
                horsePower = int.Parse(cmdArg[6]);
                acceleration = int.Parse(cmdArg[7]);
                suspension = int.Parse(cmdArg[8]);
                durability = int.Parse(cmdArg[9]);
                manager.Register(id, type, brand, model, year, horsePower, acceleration, suspension, durability);
                break;
            case "check":
                id = int.Parse(cmdArg[1]);
                Console.WriteLine(manager.Check(id));
                break;
            case "open":
                id = int.Parse(cmdArg[1]);
                type = cmdArg[2];
                length = int.Parse(cmdArg[3]);
                route = cmdArg[4];
                prizePool = int.Parse(cmdArg[5]);
                manager.Open(id, type, length, route, prizePool);
                break;
            case "participate":
                carId = int.Parse(cmdArg[1]);
                raceId = int.Parse(cmdArg[2]);
                manager.Participate(carId, raceId);
                break;
            case "start":
                raceId = int.Parse(cmdArg[1]);
                Console.WriteLine(manager.Start(raceId));
                ;
                break;
            case "park":
                carId = int.Parse(cmdArg[1]);
                manager.Park(carId);
                break;
            case "unpark":
                carId = int.Parse(cmdArg[1]);
                manager.Unpark(carId);
                break;
            case "tune":
                int tuneIndex = int.Parse(cmdArg[1]);
                string addon = cmdArg[2];
                manager.Tune(tuneIndex, addon);
                break;
        }
    }
}
