namespace _04.PascalTriangle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var matrix = new long[n][];
            var currentWidth = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new long[currentWidth];
                var currentRow = matrix[row];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;

                currentWidth++;

                if (currentRow.Length > 2)
                {
                    for (int i = 1; i < currentRow.Length-1; i++)
                    {
                        var previousRow = matrix[row - 1];
                        var prevoiousRowSum = previousRow[i] + previousRow[i - 1];
                        currentRow[i] = prevoiousRowSum;
                    }                    
                }
            }
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
