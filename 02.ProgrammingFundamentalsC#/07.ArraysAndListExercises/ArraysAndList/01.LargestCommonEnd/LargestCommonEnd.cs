using System;
using System.Linq;
class LargestCommonEnd
{
    static void Main()
    {
        var firstArray = Console.ReadLine().Split(' ').ToArray();
        var secondArray = Console.ReadLine().Split(' ').ToArray();
        var smallerLenght = Math.Min(firstArray.Length, secondArray.Length);

        var leftElement = CommonElement(firstArray, secondArray, smallerLenght);
        Array.Reverse(firstArray);
        Array.Reverse(secondArray);
        var rightElement = CommonElement(firstArray, secondArray, smallerLenght);
        var result = Math.Max(leftElement, rightElement);
        Console.WriteLine(result);
    }

    private static int CommonElement(string[] firstArray, string[] secondArray, int smallerLenght)
    {
        var counter = 0;
        for (int i = 0; i < smallerLenght; i++)
        {
            if (firstArray[i] == secondArray[i])
            {
                counter++;
            }
            else
            {
                break;
            }
        }
        return counter;
    }
}