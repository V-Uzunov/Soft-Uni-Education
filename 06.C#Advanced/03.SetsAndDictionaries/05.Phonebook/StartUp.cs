namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var phonebook = new SortedDictionary<string, string>();

            while (input[0] != "search")
            {
                var name = input[0];
                var phonenumber = input[1];

                phonebook[name] = phonenumber;

                input = Console.ReadLine()
                .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            var names = Console.ReadLine();
            while (names != "stop")
            {
                if (phonebook.ContainsKey(names))
                {
                    Console.WriteLine($"{names} -> {phonebook[names]}");
                }
                else
                {
                    Console.WriteLine($"Contact {names} does not exist.");
                }
                names = Console.ReadLine();
            }
        }
    }
}
