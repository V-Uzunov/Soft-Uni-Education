namespace _06.AMiner_sTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var resources = new Dictionary<string, int>();

            while (input != "stop")
            {
                var res = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(input))
                {
                    resources[input] += res;
                }
                else
                {
                    resources[input] = res;
                }
                input = Console.ReadLine();
            }
            foreach (var res in resources)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }
        }
    }
}
