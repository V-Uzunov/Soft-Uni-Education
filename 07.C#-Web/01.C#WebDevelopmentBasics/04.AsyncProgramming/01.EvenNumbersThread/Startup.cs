namespace _01.EvenNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            var number = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var minNum = int.Parse(number[0]);
            var maxNum = int.Parse(number[1]);

            var thread = new Thread(() => EvenNumbersThread(minNum, maxNum));
            thread.Start();
            thread.Join();
            Console.WriteLine("Thread finished work");
        }

        private static void EvenNumbersThread(int minNum, int maxNum)
        {
            for (int i = minNum; i <= maxNum; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
