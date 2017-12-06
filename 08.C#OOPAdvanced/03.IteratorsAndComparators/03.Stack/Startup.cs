namespace _03.Stack
{
    using System;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            string inputLine = String.Empty;
            var result = new MyStack<string>();

            while ((inputLine=Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(new[] {" ", ", "}, StringSplitOptions.RemoveEmptyEntries).ToList();                
                var command = tokens[0];

                switch (command)
                {
                    case "Push":
                        foreach (var item in tokens.Skip(1))
                        {
                            result.Push(item);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            result.Pop();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }                
            }
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
        }
    }
}
