namespace _02.LineNumbers
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            using (var reader = new StreamReader(@"..\..\someText.txt"))
            {
                using (var writer = new StreamWriter(@"..\..\someTextUpdate.txt"))
                {
                    var lineNumber = 1;
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"{lineNumber}: {line}");
                        line = reader.ReadLine();
                        lineNumber++;
                    }
                }
            }
        }
    }
}
