namespace _01.ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            string inputLine = string.Empty;

            var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).Skip(1);

            var result = new ListyIterator<string>();

            foreach (var s in input)                
            {
                result.Add(s);
            }
            
            while ((inputLine=Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                switch (command)
                {                                            
                    case "Move":
                        Console.WriteLine(result.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(result.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(result.Print());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            foreach (var res in result)
                            {
                                Console.Write(res + " ");
                            }
                            Console.WriteLine();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);                            
                        }
                        break;
                }
            }
        }
    }
}
