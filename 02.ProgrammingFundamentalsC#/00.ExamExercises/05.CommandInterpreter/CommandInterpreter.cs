using System;
using System.Collections.Generic;
using System.Linq;

class CommandInterpreter
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var commandLine = Console.ReadLine().Split().ToList();
        var start = 0;
        var count = 0;
        List<string> input = new List<string>();
        while (!commandLine[0].Equals("end"))
        {
            switch (commandLine[0])
            {
                case "reverse":
                    start = int.Parse(commandLine[2]);
                    count = int.Parse(commandLine[4]);
                    if (start < 0
                        || count < 0
                        || start >= numbers.Count
                        || start + count > numbers.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    input = numbers.Skip(start).Take(count).Reverse().ToList();
                    numbers.RemoveRange(start, count);
                    numbers.InsertRange(start, input);
                    break;
                case "sort":
                    start = int.Parse(commandLine[2]);
                    count = int.Parse(commandLine[4]);
                    if (start < 0
                       || count < 0
                       || start >= numbers.Count
                       || start + count > numbers.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }
                    input = numbers.Skip(start).Take(count).OrderBy(x => x).ToList();
                    numbers.RemoveRange(start, count);
                    numbers.InsertRange(start, input);
                    break;
                case "rollLeft":
                    count = int.Parse(commandLine[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    for (int i = 0; i < count % numbers.Count; i++)
                    {
                        var firstIndex = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(firstIndex);
                    }
                    break;
                case "rollRight":
                    count = int.Parse(commandLine[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }
                    for (int i = 0; i < count % numbers.Count; i++)
                    {
                        var lastIndex = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, lastIndex);
                    }
                    break;
                default:
                    break;
            }
            commandLine = Console.ReadLine().Split().ToList();
        }
        Console.WriteLine("[" + string.Join(", ", numbers) + "]");
    }
}
