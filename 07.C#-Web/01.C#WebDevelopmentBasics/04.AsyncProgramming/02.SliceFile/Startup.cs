namespace _02.SliceFile
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var filePath = Console.ReadLine();
            var destination = Console.ReadLine();
            var pieces = int.Parse(Console.ReadLine());

            SliceAsync(filePath, destination, pieces);
            Console.WriteLine("Anything else?");
            while (true)
            {
                Console.ReadLine();
            }
        }

        private static void SliceAsync(string sourceFile, string destination, int pieces)
        {

            Task.Run(() =>
            {
                Slice(sourceFile, destination, pieces);
            })
            .GetAwaiter()
            .GetResult();
        }

        private static void Slice(string sourceFile, string destination, int pieces)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            using (var fileStream = new FileStream(sourceFile, FileMode.Open))
            {
                var fileInfo = new FileInfo(sourceFile);

                var partLength = (fileStream.Length / pieces) + 1;
                var currentByte = 0;
                var filePath = string.Empty;
                for (int currentPart = 1; currentPart < pieces; currentPart++)
                {
                    filePath = $"{destination}/Part-{currentPart}{fileInfo.Extension}";


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        var buffer = new byte[partLength];

                        while (currentByte <= partLength * currentPart)
                        {
                            var readBytesCount = fileStream.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            stream.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                        Console.WriteLine("Slice complete!");
                    }
                }
            }
        }
    }
}
