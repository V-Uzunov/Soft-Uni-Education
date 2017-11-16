namespace _06.StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var firsComparator = new FirstPersonComparator();
            var secondComparator = new SecondPersonComparator();
            var n = int.Parse(Console.ReadLine());
            var firstSet = new SortedSet<Person>(firsComparator);
            var secondSet = new SortedSet<Person>(secondComparator);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

                firstSet.Add(new Person(input[0], int.Parse(input[1])));
                secondSet.Add(new Person(input[0], int.Parse(input[1])));
            }

            foreach (var person in firstSet)
            {
                Console.WriteLine(person.ToString());
            }
            foreach (var person in secondSet)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
