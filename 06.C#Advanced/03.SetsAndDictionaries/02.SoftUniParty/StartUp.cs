namespace _02.SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var guest = new SortedSet<string>();

            while (input != "PARTY")
            {
                guest.Add(input);
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                guest.Remove(input);
                input = Console.ReadLine();                
            }

            Console.WriteLine(guest.Count);
            foreach (var num in guest)
            {
                Console.WriteLine(num);
            }
        }
    }
}
