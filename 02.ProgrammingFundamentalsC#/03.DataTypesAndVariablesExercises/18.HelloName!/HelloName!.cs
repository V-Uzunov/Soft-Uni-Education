using System;

class Program
{
    static void Main()
    {
        string name = "Peter!";
        nameMethod(name);
    }

    static void nameMethod(string name)
    {
        Console.WriteLine("Hello, {0}", name);
    }
}

