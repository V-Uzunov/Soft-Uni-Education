namespace _05.DateModifier
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var first = Console.ReadLine();
            var second = Console.ReadLine();

            var dateModifier = new DateModifier
            {
                FirstDate = first,
                SecondDate = second
            };
            Console.WriteLine(dateModifier.CalculateDifferenceBetweenTwoDates());
        }
    }
}
