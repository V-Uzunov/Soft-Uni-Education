namespace _02.CardRank
{
    using System;
    using System.Text;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var sb =new StringBuilder();
            sb.AppendLine($"{input}:");

            var cardsRank = Enum.GetValues(typeof(CardRankEnum));

            foreach (var cards in cardsRank)
            {
                sb.AppendLine($"Ordinal value: {(int)cards}; Name value: {cards}");
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
