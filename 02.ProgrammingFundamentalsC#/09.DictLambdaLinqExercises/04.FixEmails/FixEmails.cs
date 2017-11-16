using System;
using System.Collections.Generic;
using System.Linq;

class FixEmails
{
    static void Main()
    {
        var name = Console.ReadLine();

        Dictionary<string, string> sequence = new Dictionary<string, string>();

        while (name != "stop")
        {
            var email = Console.ReadLine();
            var emailDomain = email.Substring(email.Length - 2).ToLower();

            if (!emailDomain.Equals("uk") && !emailDomain.Equals("us"))
            {
                sequence[name] = email;
            }

            name = Console.ReadLine();
        }
        foreach (var seq in sequence)
        {
            Console.WriteLine("{0} -> {1}", seq.Key, seq.Value);
        }
    }
}