namespace _01.Stream_Progress.Models
{
    public interface IStreamable
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
