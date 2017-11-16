using System;

public class Writer : IWriter
{
    public void Write()
    {
         Console.WriteLine();
    }

    public void Write(string element)
    {
         Console.WriteLine(element);
    }
}