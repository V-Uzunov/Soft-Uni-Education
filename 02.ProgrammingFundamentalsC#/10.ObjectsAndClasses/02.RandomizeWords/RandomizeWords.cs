using System;
using System.Collections.Generic;
using System.Linq;

class RandomizeWords
{
    static void Main()
    {
        var words = Console.ReadLine().Split().ToList();

        Random rnd = new Random();
        
        for (int i = 0; i < words.Count; i++)
        {
            var rndIndex = rnd.Next(words.Count);
            var oldValue = words[i];
            words[i] = words[rndIndex];
            words[rndIndex] = oldValue;            
        }
        Console.WriteLine(string.Join("\n", words));
    }
}