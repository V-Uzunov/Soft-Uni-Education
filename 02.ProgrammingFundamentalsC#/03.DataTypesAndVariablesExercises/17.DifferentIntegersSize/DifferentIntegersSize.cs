using System;
using System.Numerics;

class DifferentIntegersSize
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        bool isSbyte = (-128 <= n) && (n <= 127);
        bool isByte = (0 <= n) && (n <= 255);
        bool isShort = (-32768 <= n) && (n <= 32767);
        bool isUshort = (0 <= n) && (n <= 65535);
        bool isInt = (-2147483648 <= n) && (n <= 2147483647);
        bool isUint = (0 <= n) && (n <= 4294967295);
        bool isLong = (-9223372036854775808 <= n) && (n <= 9223372036854775807);
        if (isByte || isByte || isShort || isUshort || isInt || isUint || isLong)
        {
            Console.WriteLine("{0} can fit in:", n);
            if (isSbyte)
            {
                Console.WriteLine("* sbyte");
            }
            if (isByte)
            {
                Console.WriteLine("* byte");
            }
            if (isShort)
            {
                Console.WriteLine("* short");
            }
            if (isUshort)
            {
                Console.WriteLine("* ushort");
            }
             if (isInt)
            {
                Console.WriteLine("* int");
            }
            if (isUint)
            {
                Console.WriteLine("* uint");
            }
            if (isLong)
            {
                Console.WriteLine("* long");
            }
        }
        else
        {
            Console.WriteLine("{0} can't fit in any type", n);
        }
    }
}

