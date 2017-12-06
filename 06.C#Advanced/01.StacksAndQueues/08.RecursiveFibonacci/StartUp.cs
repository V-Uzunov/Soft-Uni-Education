namespace _08.RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static long[] FibNumber;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            FibNumber = new long[n];
            var result = GetFibonacci(n);
            Console.WriteLine(result);
        }

        private static long GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            if (FibNumber[n - 1] !=0)
            {
                return FibNumber[n - 1];
            }
            return FibNumber[n - 1] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
