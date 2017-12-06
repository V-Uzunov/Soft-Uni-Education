namespace _03.CardPower.Models
{
    using System;
    using System.Text;

    public class Card : IComparable<Card>
    {
        private CardRankEnum rank;
        private CardSuitEnum suit;

        public Card(string rank, string suit)
        {
            Enum.TryParse(rank, out this.rank);
            Enum.TryParse(suit, out this.suit);
        }
        public int CalculatePower()
        {
            return (int)this.rank + (int)this.suit;
        }

        public int CompareTo(Card other)
        {
            if (this.CalculatePower().CompareTo(other.CalculatePower())<0)
            {
                return this.CalculatePower();
            }
            return other.CalculatePower();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Card name: {this.rank} of {this.suit}; Card power: {CalculatePower()}");
            return sb.ToString().Trim();
        }
    }
}
