namespace _06.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var inputLine = string.Empty;
            ICollection<IBirthday> result = new List<IBirthday>();
            while ((inputLine=Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                tokens = tokens.Skip(1).ToArray();

                switch (command)
                {
                    case "Citizen":
                        result.Add(new Sitizen(tokens[0], tokens[1], tokens[2], tokens[3]));
                        break;
                    case "Pet":
                        result.Add(new Pet(tokens[0], tokens[1]));
                        break;                    
                }

            }
            var year = Console.ReadLine();

            result.Where(x=> x.Birthday.EndsWith(year))
                .Select(x=> x.Birthday)
                .ToList()
                .ForEach(x=> Console.WriteLine(x));
        }
    }
}
