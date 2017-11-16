using System.Text;

namespace _04.ConvertFromBase10ToBase_N
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            var baseN = input[0];
            var number = input[1];

            var sb = new StringBuilder();

            while (number != 0)
            {
                sb.Append(Convert.ToString(number % baseN));

                number /= baseN;
            }
            var res = sb.ToString().Reverse();

            Console.WriteLine(string.Join("", res));
        }
    }
}
