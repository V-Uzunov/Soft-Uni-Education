namespace _13.MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var firstWord = input[0];
            var secondWord = input[1];

            var firstSet = new HashSet<char>(firstWord);
            var secondSet = new HashSet<char>(secondWord);

            if (firstSet.Count == secondSet.Count)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
                
            }
        }
    }
}
