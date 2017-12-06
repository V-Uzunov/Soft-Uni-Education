namespace _02BlackBoxInteger
{
    using System;

    class Startup
    {
        static void Main()
        {
            Engine engine = new Engine();
            string result = engine.Run(typeof(BlackBoxInt));
            Console.WriteLine(result);
        }
    }
}
