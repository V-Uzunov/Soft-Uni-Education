namespace _04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];

                if (ch == '(')
                {
                    stack.Push(i);
                }
                else if (ch == ')')
                {
                    var startIndex = stack.Pop();

                    var content = input.Substring(startIndex, i - startIndex + 1);

                    Console.WriteLine(content);
                }
            }            
        }
    }
}
