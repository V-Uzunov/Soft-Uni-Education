namespace _01.Stream_Progress
{
    using Models;
    public class File : IStreamable
    {
        private string name;
        private int length;
        private int bytesSent;

        public File(string name, int length, int bytesSent)
        {
            this.Name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Name { get; set; }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}