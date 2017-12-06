using System;

public class WriteLine : IWriter
{
    public void Write()
    {
        Console.WriteLine();
    }

    public void Write(params string[] element)
    {
        Console.WriteLine(string.Join(" ", element));
    }
}