namespace _07.FoodShortage
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var inputLine = string.Empty;
            var num = int.Parse(Console.ReadLine());
            
            ICollection<IPerson> persons = new List<IPerson>();

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4)
                {
                    persons.Add(new Sitizen(input[0], input[1], input[2], input[3]));
                }
                else if (input.Length == 3)
                {
                    persons.Add(new Rebel(input[0], input[1], input[2]));
                }
            }
            while ((inputLine=Console.ReadLine()) != "End")
            {
                if (persons.Any(p => p.Name == inputLine))
                {
                    var person = persons.First(p => p.Name == inputLine);
                    person.BuyFood();
                }
            }
            var foodCount = persons.Sum(p => p.Food);

            Console.WriteLine(foodCount);
        }
    }
}
