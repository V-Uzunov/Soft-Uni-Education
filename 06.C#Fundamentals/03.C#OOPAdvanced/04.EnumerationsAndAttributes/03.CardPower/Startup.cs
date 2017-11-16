namespace _03.CardPower
{
    using System;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var cardRank = Console.ReadLine();
            var cardSuit = Console.ReadLine();
            
            var card = new Card(cardRank, cardSuit);

            var cardRank1 = Console.ReadLine();
            var cardSuit1 = Console.ReadLine();
            var card1 = new Card(cardRank1, cardSuit1);

            var res = card.CompareTo(card1);

            Console.WriteLine(res < 0 ? card : card1);
        }
    }
}
