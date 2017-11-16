namespace _02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var inputCommands = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var numberOfElements = inputCommands[0];
            var popElementNumber = inputCommands[1];
            var presentNumberInStack = inputCommands[2];

            Stack<int> stack = new Stack<int>();
            List<int> numbers = new List<int>();

            numbers = ReadNumbersFromConsole(numberOfElements, numbers);

            AddElementsInStack(stack, numbers);
            PopElementsFromStack(popElementNumber, stack);
            CheckPresentNumberAndPrint(presentNumberInStack, stack);

        }

        private static void CheckPresentNumberAndPrint(int presentNumberInStack, Stack<int> stack)
        {
            if (stack.Contains(presentNumberInStack))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {                
                Console.WriteLine(stack.Min());
            }            
        }

        private static List<int> ReadNumbersFromConsole(int numberOfElements, List<int> numbers)
        {
            numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            return numbers;
        }

        private static void AddElementsInStack(Stack<int> stack, List<int> numbers)
        {
            foreach (var item in numbers)
            {
                stack.Push(item);
            }
        }

        private static void PopElementsFromStack(int popElementNumber, Stack<int> stack)
        {
            for (int i = 0; i < popElementNumber; i++)
            {
                stack.Pop();
            }
        }
    }
}