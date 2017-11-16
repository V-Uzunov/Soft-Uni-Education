using System;

class BooleanVariable
{
    static void Main()
    {
        string str = Console.ReadLine();
        bool boo = Convert.ToBoolean(str);
        if (boo==true)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }  
    }
}