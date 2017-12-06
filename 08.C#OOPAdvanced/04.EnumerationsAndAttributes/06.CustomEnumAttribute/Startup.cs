namespace _06.CustomEnumAttribute
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attribute;
    using _03.CardPower.Models;

    public class Startup
    {
        public static void Main()
        {
            var enumName = Console.ReadLine();

            Type type = enumName == "Rank" ? typeof(CardRankEnum) : typeof(CardSuitEnum);
            
            var attributesInfo = type.GetCustomAttributes();
            foreach (var attribute in attributesInfo)
            {
                var attributr = (TypeAttribute) attribute;
                Console.WriteLine(attributr);
            }
        }
    }
}