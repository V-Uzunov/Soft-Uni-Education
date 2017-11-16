namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var users = new SortedDictionary<string, Dictionary<string, int>>();

            var lines = Console.ReadLine();

            while (lines != "end")
            {
                var tokens = lines.Split();

                var ip = tokens[0].Replace("IP=", "");
                var username = tokens[2].Replace("user=", "");

                if (users.ContainsKey(username))
                {
                    if (users[username].ContainsKey(ip))
                    {
                        users[username][ip] += 1;
                    }
                    else
                    {
                        users[username][ip] = 1;
                    }
                }
                else
                {
                    users[username] = new Dictionary<string, int>() { { ip, 1 } };
                }

                lines = Console.ReadLine();
            }
            PrintUsernameAndIp(users);
        }

        private static void PrintUsernameAndIp(SortedDictionary<string, Dictionary<string, int>> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}: ");
                Console.WriteLine($"{string.Join(", ", user.Value.Select(x => $"{x.Key} => {x.Value}"))}.");
            }
        }
    }
}
