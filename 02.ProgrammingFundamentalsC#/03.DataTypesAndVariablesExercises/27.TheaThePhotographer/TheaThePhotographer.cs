using System;
class TheaThePhotographer
{
    static void Main()
    {
        var amount = int.Parse(Console.ReadLine());
        var time = int.Parse(Console.ReadLine());
        var procent = int.Parse(Console.ReadLine());
        var timeToFiltered = int.Parse(Console.ReadLine());

        long filteredPictures =(long)Math.Ceiling((double)amount * procent / 100.0);
        long timeToSec =time * 60;
        long filteredTimeToSeconds =timeToFiltered * 60;
        long timeToPadecimalInSeconds =(amount * timeToSec)/60;
        long timeToUploadInSeconds =(filteredPictures * filteredTimeToSeconds) / 60;
        long totalTime =timeToPadecimalInSeconds + timeToUploadInSeconds;
        TimeSpan t = TimeSpan.FromSeconds(totalTime);
        var timeInFormat= t.ToString(@"d\:hh\:mm\:ss");
        Console.WriteLine(timeInFormat);
    }
}