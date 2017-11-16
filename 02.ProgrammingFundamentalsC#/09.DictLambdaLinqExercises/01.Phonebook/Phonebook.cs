using System;
using System.Collections.Generic;
using System.Linq;

class Phonebook
{
    static void Main()
    {
        var input = Console.ReadLine().Split().ToList();

        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        var name = string.Empty;
        var number = string.Empty;
        while (!input[0].Equals("END"))
        {
            var commands = input[0];
            switch (commands)
            {
                case "A":
                    name = input[1];
                    number = input[2];
                    phonebook[name] = number;
                    break;
                case "S":
                    name = input[1];
                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phonebook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                    break;                
                default:
                    break;
            }
            input = Console.ReadLine().Split().ToList();
        }
    }
}