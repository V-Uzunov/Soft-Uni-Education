namespace _07.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            var openParanthesis = new char[] { '(', '{', '[' };

            for (int i = 0; i < input.Length; i++)
            {
                if (openParanthesis.Contains(input[i]))
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Count() == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    switch (input[i])
                    {
                        case ')':
                            if (stack.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case '}':
                            if (stack.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (stack.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
