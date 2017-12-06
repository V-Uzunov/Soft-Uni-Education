namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var lines = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < lines.Length; j++)
                {
                    elements.Add(lines[j]);
                }
            }
            
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
