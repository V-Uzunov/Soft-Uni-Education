using System;

class TriplesOfLetters
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        char letter = ' ';
        char letter1 = ' ';
        char letter2 = ' ';
        for (int i = 0; i < n; i++)
        {
            letter = (char)('a' + i);
            for (int j = 0; j < n; j++)
            {
                letter1 = (char)('a' + j);
                for (int k = 0; k < n; k++)
                {
                    letter2 = (char)('a' + k);
                    Console.WriteLine("{0}{1}{2}", letter, letter1, letter2);
                }
            }
        }
    }
}

