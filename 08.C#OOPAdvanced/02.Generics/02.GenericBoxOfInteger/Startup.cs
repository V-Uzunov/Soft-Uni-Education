namespace _02.GenericBoxOfInteger
{
    using System;
    using _01.GenericBoxOfString.Models;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());

                var boxOfInt = new Box<int>(input);

                Console.WriteLine(boxOfInt.ToString());
            }
        }
    }
}
