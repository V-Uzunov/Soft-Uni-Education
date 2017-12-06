namespace _12.CharacterMultiplier
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var word1 = input[0];
            var word2 = input[1];

            var minLength = Math.Min(word1.Length, word2.Length);
            var maxLength = Math.Max(word1.Length, word2.Length);
            var sum = 0;

            for (int i = 0; i < minLength; i++)
            {
                sum += MultiplyCharsASCII(word1[i], word2[i]);
            }

            if (word1.Length != word2.Length)
            {
                string longerInput = word1.Length > word2.Length ? longerInput = word1 : longerInput = word2;

                for (int i = minLength; i < maxLength; i++)
                {
                    sum += longerInput[i];
                }
            }

            Console.WriteLine(sum);
        }

        public static int MultiplyCharsASCII(char let1, char let2)
        {
            var multiply = let1 * let2;
            return multiply;
        }
    }
}
