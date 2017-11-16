using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var r = int.Parse(Console.ReadLine());
        var c = int.Parse(Console.ReadLine());

        var matrix = new string[r][];
        for (int row = 0; row < r; row++)
        {
            matrix[row] = Console.ReadLine().Split(' ');
        }
        for (int col = 0; col < c; col++)
        {
            for (int row = r-1; row >= 0; row--)
            {
                Console.Write(matrix[row][col]+" ");
            }
            Console.WriteLine();
        }
    }
}

