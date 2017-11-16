namespace _01.SchoolCompetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var categories = new Dictionary<string, SortedSet<string>>();
            var result = new Dictionary<string, int>();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var category = tokens[1];
                var point = int.Parse(tokens[2]);

                if (!categories.ContainsKey(name))
                {
                    categories[name]= new SortedSet<string>();
                }

                if (!result.ContainsKey(name))
                {
                    result[name] = 0;
                }

                result[name] += point;
                categories[name].Add(category);
            }
            var orderRes = result
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);

            foreach (var nameKVP in orderRes)
            {
                var categoryRes = categories[nameKVP.Key];

                Console.WriteLine($"{nameKVP.Key}: {nameKVP.Value} [{string.Join(", ", categoryRes)}]");
            }
        }
    }
}
