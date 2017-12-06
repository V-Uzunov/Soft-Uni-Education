namespace _11.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { " ", ",", ".", "?", "!" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var palindrom = new SortedSet<string>();

            foreach (var word in input)
            {
                if (word == string.Join("", word.Reverse()))
                {
                    palindrom.Add(word);
                }
            }
            Console.WriteLine($"[{string.Join(", ", palindrom)}]");
        }
    }
}
