namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        static Stack<int> stack = new Stack<int>();

        private static int max = 0;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var query = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                              

                ExecuteCommand(query);
            }
        }

        private static void ExecuteCommand(List<int> query)
        {
            switch (query[0])
            {
                case 1:
                    stack.Push(query[1]);
                    if (query[1] > max)
                    {
                        max = query[1];
                    }
                    break;
                case 2:
                    int element = stack.Pop();
                    if (element == max && stack.Count > 0)
                    {
                        max = stack.Max();
                    }
                    else if (element == max && stack.Count == 0)
                    {
                        max = 0;
                    }
                    break;
                case 3:
                    Console.WriteLine(max);
                    break;
            }
        }
    }
}
