using System;
using System.Collections.Generic;
using System.Linq;

class AMinerTask
{
    static void Main()
    {
        Dictionary<string, long> sequence = new Dictionary<string, long>();
        var resources = Console.ReadLine();
        while (resources != "stop")
        {
            var quantity = long.Parse(Console.ReadLine());
            if (sequence.ContainsKey(resources))
            {
                sequence[resources] += quantity;
            }
            else
            {
                sequence[resources] = quantity;
            }
            resources = Console.ReadLine();
        }
        foreach (var seq in sequence)
        {
            Console.WriteLine("{0} -> {1}", seq.Key, seq.Value);
        }
    }
}