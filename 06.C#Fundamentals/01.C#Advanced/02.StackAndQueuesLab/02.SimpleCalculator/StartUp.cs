namespace _02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                var firsNumber = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((firsNumber + secondNumber).ToString());
                }
                else
                {
                    stack.Push((firsNumber - secondNumber).ToString());
                }
            }
            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
