using System;
using System.Collections.Generic;
using System.Linq;

class ShortWordsSorted
{
    static void Main()
    {
        string[] words = Console.ReadLine()
                           .ToLower()
                           .Split(new char[] { ':', '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }
                           , StringSplitOptions.RemoveEmptyEntries)
                           .ToArray();
        string[] result = words
                        .Where(word => word.Length < (5))
                        .OrderBy(word => word)
                        .Distinct().ToArray();

        Console.WriteLine(string.Join(", ", result));
    }
}