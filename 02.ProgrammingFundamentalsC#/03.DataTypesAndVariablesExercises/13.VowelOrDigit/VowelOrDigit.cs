using System;

class VowelOrDigit
{
    static void Main()
    {
        char ch = char.Parse(Console.ReadLine());
        if (ch=='a' || ch=='e' || ch=='i' || ch=='o' || ch == 'u')
        {
            Console.WriteLine("vowel");
        }
        else if (ch=='1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9'|| ch=='0')
        {
            Console.WriteLine("digit");
        }
        else
        {
            Console.WriteLine("other");
        }
    }
}

