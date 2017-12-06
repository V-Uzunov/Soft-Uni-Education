namespace _01.Stream_Progress
{
    using Models;
    public class Music : IStreamable
    {
        private string artist;
        private string album;
        private int length;
        private int bytesSent;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.Artist = artist;
            this.Album = album;
            this.Length = length;
            this.BytesSent = bytesSent;

        }

        public string Artist { get;protected set; }

        public string Album { get; protected set; }

        public int Length { get; protected set; }

        public int BytesSent { get; protected set; }
    }
}