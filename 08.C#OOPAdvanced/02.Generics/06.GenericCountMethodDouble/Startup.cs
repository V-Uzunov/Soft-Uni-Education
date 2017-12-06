namespace _06.GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;
    using _01.GenericBoxOfString.Models;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var box= new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                box.Add(input);
            }
            var element = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CompareCounter(element));

        }
    }
}
