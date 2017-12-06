using System.Text;

namespace _02.StringLength
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = string.Empty;
            
            if (input.Length > 20)
            {
                result = input.Substring(0, 20);                
            }
            else
            {
                result=input.PadRight(50, '*').Substring(0, 20);
            }
            Console.WriteLine(result);
        }
    }
}
