namespace _04.OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var result = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);

                result.Add(person);
            }

            result.Where(x=> x.age>30).OrderBy(x=> x.name).ToList().ForEach(x=> Console.WriteLine($"{x.name} - {x.age}"));
        }
    }
}
