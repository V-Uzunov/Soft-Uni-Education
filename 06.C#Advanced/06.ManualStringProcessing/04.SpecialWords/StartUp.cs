using System.Data;
using System.Diagnostics;

namespace _04.SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(new[] { " ", "(", ")", "[", "]", "<", ">", ",", "-", "!", "?" },
                StringSplitOptions.RemoveEmptyEntries); ;
           
            var text = Console.ReadLine().Split(new[] { " ", "(", ")", "[", "]", "<", ">", ",", "-", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);

            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict[word] = 0;
                }
                foreach (var txt in text)
                {
                    if (txt.Equals(word))
                    {
                        dict[word] += 1;
                    }
                }
            }

            foreach (var i in dict)
            {
                Console.WriteLine($"{i.Key} - {i.Value}");
            }
        }
    }
}
