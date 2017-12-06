namespace _01.SumOfAllElementsOfMatrix
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var sum = 0;
            var matrix = new int[input[0]][];
            for (int row = 0; row < matrix.Length; row++)
            {
                var numbers = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = numbers;
            }
            
            
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    sum += matrix[row][col];
                }
            }
            Console.WriteLine(string.Join("\n", input[0], input[1], sum));
        }
    }
}
