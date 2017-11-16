using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbers
{
    public class ReverseNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> stack = new Stack<int>();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            while (stack.Count !=0)
            {
                Console.Write(stack.Pop()+" ");
            }
        }
    }
}
