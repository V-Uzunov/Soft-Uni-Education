namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            string inputLine;
            var resultOfPeople = new List<Person>();

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                resultOfPeople.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
            var index = int.Parse(Console.ReadLine());
            var person = resultOfPeople[index - 1];

            var numberOfEquelPeople = resultOfPeople.Count(x => x.CompareTo(person) == 0);
            var numberOfNotEquelPeople = resultOfPeople.Count(x => x.CompareTo(person) != 0);

            if (numberOfEquelPeople < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{numberOfEquelPeople} {numberOfNotEquelPeople} {resultOfPeople.Count}");
            }           
        }
    }
}
