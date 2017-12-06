namespace _03.Ferrari
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

           var name = Console.ReadLine();

            var car = new Ferrari(name);

            Console.WriteLine(car.ToString());
        }
    }
}
