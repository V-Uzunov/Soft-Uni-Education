namespace _01.OddLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var reader = new StreamReader(@"simpleText.txt");
            using (reader)
            {
                var lineNumber = 1;
                var line = reader.ReadLine();

                while (line != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"Line number -> {lineNumber}: {line}");
                    }
                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
