namespace _03.SquaresInMatrix
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

            var matrix = new string[input[0]][];
            var counter = 0;


            for (int i = 0; i < matrix.Length; i++)
            {
                var chars = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                matrix[i] = new string[input[1]];
                matrix[i] = chars;
            }

            for (int row = 0; row < matrix.Length-1; row++)
            {
                for (int col = 0; col < matrix[row].Length-1; col++)
                {
                    if ((matrix[row][col] == matrix[row+1][col] 
                        && matrix[row][col+1]==matrix[row+1][col+1])
                        && matrix[row][col]==matrix[row][col+1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
