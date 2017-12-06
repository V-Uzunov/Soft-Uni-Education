namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var name = Console.ReadLine();            
            var dict = new Dictionary<string, string>();

            while (name != "stop")
            {
                var email = Console.ReadLine();
                if (!email.Contains(".us") || email.Contains(".uk"))
                {
                    dict[name] = email;
                }

                name = Console.ReadLine();                
            }

            foreach (var users in dict)
            {
                Console.WriteLine($"{users.Key} -> {users.Value}");
            }
        }
    }
}
