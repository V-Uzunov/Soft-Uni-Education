namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var symbol = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!symbol.ContainsKey(input[i]))
                {
                    symbol.Add(input[i], 0);
                }
                symbol[input[i]]++;
            }
            foreach (var item in symbol)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
