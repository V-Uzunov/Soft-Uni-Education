namespace _03.GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var zeroReminder = input.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            var oneReminder = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            var twoReminder = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", zeroReminder));
            Console.WriteLine(string.Join(" ", oneReminder));
            Console.WriteLine(string.Join(" ", twoReminder));
        }
    }
}
