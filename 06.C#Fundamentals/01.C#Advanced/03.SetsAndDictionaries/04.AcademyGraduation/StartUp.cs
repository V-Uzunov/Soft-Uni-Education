namespace _04.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dict = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var list = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                    .ToList();

                dict.Add(name, list);
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} is graduated with {item.Value.Average()}");
            }
        }
    }
}
