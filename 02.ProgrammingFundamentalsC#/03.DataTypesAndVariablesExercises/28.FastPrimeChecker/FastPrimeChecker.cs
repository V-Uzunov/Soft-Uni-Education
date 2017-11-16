using System;

class FastPrimeChecker
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int currentNumber = 2; currentNumber <= n; currentNumber++)
        {
            bool isPrime = true;
            for (int nextNumbers = 2; nextNumbers <= Math.Sqrt(currentNumber); nextNumbers++)
            {
                if (currentNumber % nextNumbers == 0)
                {
                    isPrime = false;
                }
            }            
            Console.WriteLine($"{currentNumber} -> {isPrime}");
        }
    }
}