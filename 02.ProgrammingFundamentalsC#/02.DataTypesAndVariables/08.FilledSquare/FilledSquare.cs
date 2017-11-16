using System;

class FilledSquare
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        printHeadRoll(n);
        for (int i = 0; i < n-2; i++)
        {
            printMiddle(n, '-');
        }
        printHeadRoll(n);
    }
    private static void printMiddle(int n, char ch)
    {
        Console.Write(ch);
        for (int i = 0; i < n-1; i++)
        {
            Console.Write("\\/");
        }
        Console.WriteLine(ch);
    }

    private static void printHeadRoll(int n)
    {
        Console.WriteLine(new string('-', n*2));
    }
}

