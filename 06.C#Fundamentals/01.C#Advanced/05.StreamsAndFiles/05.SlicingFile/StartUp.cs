namespace _05.SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int parts = int.Parse(Console.ReadLine());
            var sourceFile = @"../../originalFile.jpg";
            var destinationDirectory = @"../../DestinationDirectory/";
            var assembledDirectory = @"../../AssembledDirectory";

            CreateFolder(destinationDirectory);
            CreateFolder(assembledDirectory);

            Slice(sourceFile, destinationDirectory, parts);

            var files = Directory.GetFiles(destinationDirectory).ToList();

            Assemble(files, assembledDirectory);
        }

        private static void CreateFolder(string directory)
        {
            bool exists = Directory.Exists(directory);

            if (!exists)
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            using (FileStream writer = new FileStream(destinationDirectory + "\\" + "assembled.jpg", FileMode.Create, FileAccess.Write))
            {
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        var buffer = new byte[1024];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);

                        while (readBytes != 0)
                        {
                            writer.Write(buffer, 0, readBytes);

                            readBytes = reader.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }

            Console.WriteLine("Assembling Done.");
        }

        private static void Slice(string sourcePath, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourcePath, FileMode.Open))
            {
                int partLength = (int)Math.Ceiling((double)reader.Length / parts);
                var buffer = new byte[partLength];

                var i = 0;
                while (true)
                {
                    int readBytes = reader.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0)
                    {
                        break;
                    }

                    using (FileStream outputFile =
                        new FileStream(destinationDirectory + "\\" + "part-" + i.ToString() + ".jpg", FileMode.CreateNew, FileAccess.Write))
                    {
                        outputFile.Write(buffer, 0, readBytes);
                        i++;
                    }
                }
            }

            Console.WriteLine("Slicing Done.");
        }
    }
}
