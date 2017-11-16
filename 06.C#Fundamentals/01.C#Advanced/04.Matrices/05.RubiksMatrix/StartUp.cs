namespace _05.RubiksMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = input[0];
            var cols = input[1];

            var matrix = new int[rows][];
            var count = 1;
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = count;
                    count++;
                }
            }

            var commandsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNum; i++)
            {
                var commandsToken = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var rcIndex = int.Parse(commandsToken[0]);
                var direction = commandsToken[1];
                var moves = int.Parse(commandsToken[2]);

                switch (direction)
                {
                    case "up":
                        MoveCols(matrix, rcIndex, moves);
                        break;
                    case "down":
                        MoveCols(matrix, rcIndex, rows - moves % rows);
                        break;
                    case "left":
                        MoveRows(matrix, rcIndex, moves);
                        break;
                    case "right":
                        MoveRows(matrix, rcIndex, cols - moves % cols);
                        break;
                }                
            }

            var element = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col]==element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    var currentElement = matrix[row][col];
                                    matrix[row][col] = element;
                                    matrix[r][c] = currentElement;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }
        }

        private static void MoveRows(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix[0].Length];

            for (int col = 0; col < matrix[0].Length; col++)
            {
                temp[col] = matrix[rcIndex][(col + moves) % matrix[0].Length];
            }
            matrix[rcIndex] = temp;
        }

        private static void MoveCols(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix.Length];

            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[(row + moves) % matrix.Length][rcIndex];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][rcIndex] = temp[row];
            }
        }
    }
}
