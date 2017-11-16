using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class LineNumbers
{
    static void Main()
    {
        string[] input = File.ReadAllLines("input.txt");

        for (int i = 0; i < input.Length; i++)
        {
            File.AppendAllText("output.txt", $"{i + 1}. {input[i]}{Environment.NewLine}");
        }
    }
}