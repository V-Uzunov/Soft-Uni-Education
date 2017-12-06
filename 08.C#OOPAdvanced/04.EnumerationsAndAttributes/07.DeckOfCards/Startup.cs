namespace _07.DeckOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _03.CardPower.Models;

    public class Startup
    {
        public static void Main()
        {
            var rankCard = Enum.GetValues(typeof(CardRankEnum));
            var suitCard = Enum.GetValues(typeof(CardSuitEnum));

            foreach (var suit in suitCard)
            {
                foreach (var rank in rankCard)
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}
