namespace _04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var addElementNumber = input[0];
            var removeElement = input[1];
            var containElement = input[2];

            Queue<int> queue = new Queue<int>();

            AddElementInQueue(addElementNumber, queue);
            RemoveElements(removeElement, queue);
            CheckEndPrintElements(containElement, queue);
        }

        private static void CheckEndPrintElements(int containElement, Queue<int> queue)
        {
            if (queue.Contains(containElement))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }

        private static void RemoveElements(int removeElement, Queue<int> queue)
        {
            for (int i = 0; i < removeElement; i++)
            {
                queue.Dequeue();
            }
        }

        private static void AddElementInQueue(int addElementNumber, Queue<int> queue)
        {
            for (int i = 0; i < 1; i++)
            {
                var elements = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

                foreach (var item in elements)
                {
                    queue.Enqueue(item);
                }
            }
        }
    }
}