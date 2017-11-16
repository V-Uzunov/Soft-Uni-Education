using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class OddLines
{
    static void Main()
    {
        string[] text = File.ReadAllLines("input.txt");

        File.WriteAllLines("output.txt", text.Where((lines, index) => index % 2 == 1));
    }
}