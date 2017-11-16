﻿namespace _07.DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] filePaths = Directory.GetFiles(@"../../", "*.*", SearchOption.AllDirectories);

            List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();

            var sorted =
                files.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            StreamWriter writer = new StreamWriter(desktop + "/report.txt");

            foreach (var group in sorted)
            {
                writer.WriteLine(group.Key);

                foreach (var y in group)
                {
                    writer.WriteLine("--{0} - {1:F3}kb", y.Name, y.Length / 1024.0);
                }
            }

            writer.Close();

            System.Diagnostics.Process.Start(desktop + "/report.txt");
        }
    }
}
