namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var countrys = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {

                var tokens = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                var city = tokens[0];
                var country = tokens[1];
                var population = long.Parse(tokens[2]);

                if (!countrys.ContainsKey(country))
                {
                    countrys[country] = new Dictionary<string, long>();
                }
                countrys[country][city] = population;

                input = Console.ReadLine();
            }
            PrintCountryCityAndPopulation(countrys);
        }

        private static void PrintCountryCityAndPopulation(Dictionary<string, Dictionary<string, long>> countrys)
        {
            foreach (var cityEntry in countrys.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{cityEntry.Key} (total population: {cityEntry.Value.Values.Sum()})");

                foreach (var populationEntry in cityEntry.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{populationEntry.Key}: {populationEntry.Value}");
                }
            }
        }
    }
}
