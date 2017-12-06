namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < input; i++)
            {
                var fibFirst = stack.Pop();
                var fibSec = stack.Peek() + fibFirst;
                stack.Push(fibFirst);
                stack.Push(fibSec);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
