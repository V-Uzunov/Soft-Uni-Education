using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main()
    {
        var text = Console.ReadLine().ToUpper();
        string pattern = @"(\D+)(\d+)";

        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        StringBuilder sb = new StringBuilder();

        foreach (Match match in matches)
        {
            for (int i = 0; i < int.Parse(match.Groups[2].ToString()); i++)
            {
                sb.Append(match.Groups[1]);
            }
        }
        var count = sb.ToString().Distinct().Count();

        Console.WriteLine($"Unique symbols used: {count}");
        Console.WriteLine(sb);
    }
}