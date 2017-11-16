using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class WordCount
{
    static void Main()
    {
        string[] words = File.ReadAllText("words.txt").ToLower().Split();
        string[] text = File.ReadAllText("text.txt").ToLower()
                 .Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach (string word in words)
        {
            wordCount[word] = 0;
        }

        foreach (string word in text)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
        }
        foreach (var item in wordCount.OrderByDescending(x=> x.Value))
        {
            File.AppendAllText("output.txt", $"{item.Key} - {item.Value}{Environment.NewLine}");
        }
    }
}