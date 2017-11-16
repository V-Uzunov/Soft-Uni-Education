using System;

class Greeting
{
    static void Main()
    {
        var firstName = Console.ReadLine();
        var lastName = Console.ReadLine();
        var age = byte.Parse(Console.ReadLine());

        Console.WriteLine($"Hello, { firstName } { lastName }. You are { age } years old.");
    }
}

