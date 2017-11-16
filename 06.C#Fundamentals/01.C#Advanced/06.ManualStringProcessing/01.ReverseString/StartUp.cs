using System.Text;

namespace _01.ReverseString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            Array.Reverse(input);

            Console.WriteLine(input);
        }
    }
}
