namespace _09.TextFilter
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var bannWords = Console.ReadLine()
                .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var text = Console.ReadLine();

            foreach (var word in bannWords)
            {
                if (text.Contains(word))
                {
                    text = text.Replace(word, new string('*', word.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
