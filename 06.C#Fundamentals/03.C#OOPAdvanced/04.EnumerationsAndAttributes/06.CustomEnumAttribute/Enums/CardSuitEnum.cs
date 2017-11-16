namespace _03.CardPower.Models
{
    using _06.CustomEnumAttribute.Attribute;

    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum CardSuitEnum
    {
        Clubs,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
}
