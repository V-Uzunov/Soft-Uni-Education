namespace _01.CardSuit
{
    using System;
    using System.Text;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var cards = Enum.GetValues(typeof(CardEnum));
            var input = Console.ReadLine();

            var sb = new StringBuilder();
            sb.AppendLine($"{input}:");

            foreach (var card in cards)
            {
                sb.AppendLine($"Ordinal value: {(int)card}; Name value: {card}");
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
