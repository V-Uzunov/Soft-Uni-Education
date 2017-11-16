namespace _01HarestingFields.Models
{
    using System;
    using Core;

    public class Engine
    {
        private Commands commands;

        public Engine()
        {
            this.commands = new Commands();
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "HARVEST")
            {
                var cmd = inputLine;
                switch (cmd)
                {
                    case "private":
                        Console.WriteLine(commands.GetPrivateFields(typeof(HarvestingFields).ToString()));
                        break;
                    case "protected":
                        Console.WriteLine(commands.GetProtectedFields(typeof(HarvestingFields).ToString()));
                        break;
                    case "public":
                        Console.WriteLine(commands.GetPublicFields(typeof(HarvestingFields).ToString()));
                        break;
                    case "all":
                        Console.WriteLine(commands.GetAllFields(typeof(HarvestingFields).ToString()));
                        break;
                }
            }
        }
    }
}
