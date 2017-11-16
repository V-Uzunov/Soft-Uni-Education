namespace _01.MatrixOfPalindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var c = input[0];
            var r = input[1];

            var alphabets = new string[] {  "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u",
                "v", "w", "x", "y", "z"};

            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    Console.Write($"{alphabets[i]}{alphabets[i+j]}{alphabets[i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
