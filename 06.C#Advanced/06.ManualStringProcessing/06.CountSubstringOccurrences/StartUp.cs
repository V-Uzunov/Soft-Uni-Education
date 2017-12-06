namespace _06.CountSubstringOccurrences
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var word = Console.ReadLine().ToLower();

            var counter = 0;
            var startIndex = 0;

            while (true)
            {
                var index = text.IndexOf(word, startIndex);

                if (index >= 0)
                {
                    counter++;
                    startIndex = index + 1;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
