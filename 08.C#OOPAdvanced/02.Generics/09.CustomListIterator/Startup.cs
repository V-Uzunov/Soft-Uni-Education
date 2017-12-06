namespace _09.CustomListIterator
{
    using System;
    using System.Linq;
    using _01.GenericBoxOfString.Models;

    public class Startup
    {
        public static void Main()
        {
            string inputList;
            var box = new Box<string>();
            while ((inputList = Console.ReadLine()) != "END")
            {
                var tokens = inputList.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = tokens[0];
                tokens = tokens.Skip(1).ToList();

                switch (command)
                {
                    case "Add":
                        box.Add(tokens[0]);
                        break;
                    case "Remove":
                        box.Remove(int.Parse(tokens[0]));
                        break;
                    case "Contains":
                        Console.WriteLine(box.Contains(tokens[0]));
                        break;
                    case "Swap":
                        box.Swap(int.Parse(tokens[0]), int.Parse(tokens[1]));
                        break;
                    case "Sort":
                        box.Sort();
                        break;
                    case "Greater":
                        Console.WriteLine(box.Greater(tokens[0]));
                        break;
                    case "Max":
                        box.Max();
                        break;
                    case "Min":
                        box.Min();
                        break;
                    case "Print":
                        box.Print();
                        break;
                }
            }
        }
    }
}
