using System;
using System.Collections.Generic;
using System.Linq;
class MatrixOfLetters
{
    static void Main()
    {
        var r = int.Parse(Console.ReadLine());
        var c = int.Parse(Console.ReadLine());

        var letter = 'A';
        var matrix = new char[r][];
        for (int row = 0; row < r; row++)
        {
            matrix[row] = new char[c];
            for (int col = 0; col < c; col++)
            {
                matrix[row][col] = letter;
                letter++;
            }
        }
        foreach (var item in matrix)
        {
            Console.WriteLine(string.Join(" ", item));
        }
    }
}

