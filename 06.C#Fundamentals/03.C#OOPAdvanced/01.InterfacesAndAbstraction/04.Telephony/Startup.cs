namespace _04.Telephony
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {

            var number = Console.ReadLine().Split(' ');
            var site = Console.ReadLine().Split(' ');
            var phone = new Smartphone(number, site);

            Console.WriteLine(phone.ToString());
        }
    }
}