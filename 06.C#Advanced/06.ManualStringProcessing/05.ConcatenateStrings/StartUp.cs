namespace _05.ConcatenateStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var words = Console.ReadLine();

                sb.Append(words + " ");
            }
            Console.WriteLine(sb);
        }
    }
}
