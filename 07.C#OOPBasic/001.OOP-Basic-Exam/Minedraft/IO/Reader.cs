using System;

public class Reader : IReader
{
    public string Read()
    {
        return Console.ReadLine();
    }
}