namespace _04.Froggy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var stonesInput = Console.ReadLine()
                .Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var jumpsResult = new Lake(stonesInput);
            
            Console.WriteLine(string.Join(", ", jumpsResult));
        }
    }
}
