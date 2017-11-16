using System;

class PrintPartOfASCIITable
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        char cha = Convert.ToChar(a);
        char chb = Convert.ToChar(b);
        while (cha<=chb)
        {
            Console.Write("{0} ", cha);
            cha++;
        }
        //for (int i = cha; i <= chb; i++)
        //{
        //    Console.Write("{0} ", (char)i);
        //}
    }
}

