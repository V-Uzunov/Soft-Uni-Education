namespace _04.GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _01.GenericBoxOfString.Models;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                var box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }
            var index = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var firstIndex = index[0];
            var secondIndex = index[1];

            GenericSwapMethod(boxes, firstIndex, secondIndex);

            for (int i = 0; i < boxes.Count; i++)
            {
                Console.WriteLine(boxes[i]);
            }
        }

        public static void GenericSwapMethod<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            Box<T> firstBox = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = firstBox;
        }
    }
}
