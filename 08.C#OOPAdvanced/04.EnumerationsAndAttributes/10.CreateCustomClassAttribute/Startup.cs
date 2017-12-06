namespace CreateCustomClassAtrribute
{
    using System;
    using System.Linq;
    using Attributes;

    [Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class Startup
    {
        public static void Main()
        {
            var inputLine = string.Empty;

            var attr = (InfoAttribute)typeof(Startup).GetCustomAttributes(true).FirstOrDefault();

            while ((inputLine = Console.ReadLine()) != "END")
            {
                Console.WriteLine(attr.PrintInfo(inputLine));
            }
        }
    }
}
