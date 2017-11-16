using System;
class IndexOfLetters
{
    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();

        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine("{0} -> {1}", input[i], input[i] - 'a');
        }
    }
}