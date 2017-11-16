using System;
using System.Linq;
class Program
{
    static void Main()
    {
        char[] inputOne = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        char[] inputTwo = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        int loops = Math.Min(inputOne.Length, inputTwo.Length);
        for (int i = 0; i < loops; i++)
        {
            if (inputOne[i] < inputTwo[i])
            {
                Console.WriteLine(inputOne);
                Console.WriteLine(inputTwo);
                break;
            }
            else if (inputOne[i] > inputTwo[i])
            {
                Console.WriteLine(inputTwo);
                Console.WriteLine(inputOne);
                break;
            }
            else if (inputOne.Length == inputTwo.Length && inputOne[i] == inputTwo[i])
            {
                Console.WriteLine(inputOne);
                Console.WriteLine(inputTwo);
                break;
            }
            else if (inputOne.Length != inputTwo.Length && inputOne[i] == inputTwo[i])
            {
                Console.WriteLine(inputOne.Length > inputTwo.Length ? inputTwo : inputOne);
                Console.WriteLine(inputOne.Length < inputTwo.Length ? inputTwo : inputOne);
                break;
            }
        }
    }
}