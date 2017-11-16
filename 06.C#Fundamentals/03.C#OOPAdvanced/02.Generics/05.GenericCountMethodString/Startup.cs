namespace _05.GenericCountMethodString
{
    using System;
    using System.Collections.Generic;
    using _01.GenericBoxOfString.Models;

    public class Startup
    {
        public static void Main()
        {
            Box<string> box = new Box<string>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();
                box.Add(inputLine);
            }

            var compareElemment = Console.ReadLine();
            Console.WriteLine(box.CompareCounter(compareElemment));
        }
    }
}
