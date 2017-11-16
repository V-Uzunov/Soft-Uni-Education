namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var uniqueNames = new HashSet<string>();


            for (int i = 0; i < n; i++)
            {
                var names = Console.ReadLine();

                uniqueNames.Add(names);
            }

            foreach (var names in uniqueNames)
            {
                Console.WriteLine(names);
            }
        }
    }
}
