namespace _02.SquareWithMaximumSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[input[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                var nums = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = nums;
            }

            var maxSum = int.MinValue;
            var rowRes = 0;
            var colRes = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var cube = matrix[row][col] + matrix[row + 1][col] +
                        matrix[row][col + 1] + matrix[row + 1][col + 1];                  
                    if (maxSum < cube)
                    {                        
                        maxSum = cube;

                        rowRes = row;
                        colRes = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[rowRes][colRes]} {matrix[rowRes][colRes+1]}");
            Console.WriteLine($"{matrix[rowRes+1][colRes]} {matrix[rowRes+1][colRes+1]}");
            Console.WriteLine(maxSum);
        }
    }
}
