using System;
using System.Collections.Generic;
using System.Linq;

class OddOccurrences
{
    static void Main()
    {
        var words = Console.ReadLine().ToLower().Split().ToArray();

        Dictionary<string, int> counts = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            if (counts.ContainsKey(words[i]))
            {
                counts[words[i]]++;
            }
            else
            {
                counts[words[i]] = 1;
            }
        }
        var result = new List<string>();

        foreach (var word in counts.Keys)
        {
            if (counts[word] % 2 !=0)
            {
                result.Add(word);
            }            
        }
        Console.WriteLine(string.Join(", ", result));
    }
}