namespace _01.ReverseStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            while (stack.Count != 0)
            {
                
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
