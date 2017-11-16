namespace _05.ConvertFromBaseNToBase_10
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                 .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                 .Select(BigInteger.Parse)
                 .ToArray();

            var baseN = numbers[0];
            var numb = numbers[1];
            string characters = "0123456789ABCDEF";
            BigInteger results = 0;

            foreach (char digit in numb.ToString().ToArray())
            {
                results = (baseN * results) + characters.ToUpper().IndexOf(digit);
            }
            Console.WriteLine(results);
        }
    }
}
