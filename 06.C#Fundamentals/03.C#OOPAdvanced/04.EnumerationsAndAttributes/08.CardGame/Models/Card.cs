using System;
using Card_Problem.Enums;

namespace Card_Problem.Models
{
    using System.Text;

    public class Card : IComparable<Card>
    {
        public CardRank CardRank { get; protected set; }
        public CardSuits CardSuits { get; protected set; }

        public Card(string rank, string suit)
        {
            this.CardRank = (CardRank) Enum.Parse(typeof(CardRank), rank);
            this.CardSuits = (CardSuits) Enum.Parse(typeof(CardSuits), suit);
        }

        public int CalculatePower()
        {
            return (int) this.CardRank + (int) this.CardSuits;
        }

        public int CompareTo(Card other)
        {
            if (this.CalculatePower().CompareTo(other.CalculatePower()) < 0)
            {
                return this.CalculatePower();
            }
            return other.CalculatePower();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Card name: {this.CardRank} of {this.CardSuits}; Card power: {CalculatePower()}");
            return sb.ToString().Trim();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Card card = obj as Card;

            return this.CalculatePower().Equals(card.CalculatePower());
        }
    }
}
