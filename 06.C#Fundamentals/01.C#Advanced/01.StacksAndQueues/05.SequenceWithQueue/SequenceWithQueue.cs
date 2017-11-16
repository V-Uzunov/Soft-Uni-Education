namespace _05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            var currentElement = long.Parse(Console.ReadLine());            
            Queue<long> queue = new Queue<long>();
            var count = 1;

            queue.Enqueue(currentElement);

            Console.Write(currentElement+" ");

            for (int i = count; i < 50; i++)
            {
                currentElement = queue.Dequeue();

                var seq1 = currentElement + 1;
                queue.Enqueue(seq1);
                Console.Write(seq1 + " ");
                count++;
                if (count < 50)
                {
                    var seq2 = 2 * currentElement + 1;
                    queue.Enqueue(seq2);
                    Console.Write(seq2 + " ");
                    count++;
                }
                else break;
                if (count < 50)
                {
                    var seq3 = currentElement + 2;
                    queue.Enqueue(seq3);
                    Console.Write(seq3 + " ");
                    count++;
                }
                else break;
            }
        }
    }
}
