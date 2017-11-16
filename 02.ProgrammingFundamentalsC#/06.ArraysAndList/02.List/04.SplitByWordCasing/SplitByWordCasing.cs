using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SplitByWordCasing
{

    static void Main()
    {
        var separators = new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' };
        var text = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var lowerCaseWords = new List<string>();
        var mixedCaseWords = new List<string>();
        var upperCaseWords = new List<string>();

        foreach (var word in text)
        {
            var type = GetWordType(word);
            if (type == WordType.upperCase)
            {
                upperCaseWords.Add(word);
            }
            else if (type == WordType.lowerCase)
            {
                lowerCaseWords.Add(word);
            }
            else
            {
                mixedCaseWords.Add(word);
            }
        }
        Console.WriteLine("Lower-case: "+ string.Join(", ", lowerCaseWords));
        Console.WriteLine("Mixed-case: "+ string.Join(", ", mixedCaseWords));
        Console.WriteLine("Upper-case: "+ string.Join(", ", upperCaseWords));
    }
    enum WordType { lowerCase, mixedCase, upperCase }

    private static WordType GetWordType(string word)
    {
        var lower = 0;
        var upper = 0;
        foreach (var l in word)
        {
            if (char.IsUpper(l))
            {
                upper++;
            }
            else if (char.IsLower(l))
            {
                lower++;
            }
        }
        if (upper==word.Length)
        {
            return WordType.upperCase;
        }
        if (lower==word.Length)
        {
            return WordType.lowerCase;
        }
        return WordType.mixedCase;
    }
}
