namespace _01.GenericBoxOfString
{
    using System;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var box = new Box<string>(input);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
