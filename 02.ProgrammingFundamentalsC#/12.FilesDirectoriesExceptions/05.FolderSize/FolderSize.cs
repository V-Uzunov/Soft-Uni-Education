using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FolderSize
{
    static void Main()
    {
        string[] files = Directory.GetFiles("TestFolder");

        double sum = 0;

        foreach (var file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            sum += fileInfo.Length;
        }
        sum = sum / 1024 / 1024;

        File.WriteAllText("output.txt", sum.ToString());
    }
}