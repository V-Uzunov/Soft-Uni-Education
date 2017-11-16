namespace _03.CardPower.Models
{
    using _06.CustomEnumAttribute.Attribute;

    [Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
    public enum CardRankEnum
    {
        Ace=14,
        Two=2,
        Three=3,
        Four=4,
        Five=5,
        Six=6,
        Seven=7,
        Eight=8,
        Nine=9,
        Ten=10,
        Jack=11,
        Queen=12,
        King=13
    }
}
