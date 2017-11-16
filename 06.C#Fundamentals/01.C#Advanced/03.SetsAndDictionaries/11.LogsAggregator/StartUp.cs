namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main()
        {
            var userLogs = new SortedDictionary<string, SortedDictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ipAddress = data[0];
                string user = data[1];
                int sessionDuration = int.Parse(data[2]);

                if (!userLogs.ContainsKey(user))
                {
                    userLogs[user] = new SortedDictionary<string, int>();
                }                    
                if (!userLogs[user].ContainsKey(ipAddress))
                {
                    userLogs[user][ipAddress] = 0;
                }                    
                userLogs[user][ipAddress] += sessionDuration;
            }
            foreach (var userPair in userLogs)
            {
                Console.WriteLine($"{userPair.Key}: {userPair.Value.Select(x => x.Value).Sum()} [{string.Join(", ", userPair.Value.Select(x => x.Key))}]"); 
            }
        }
    }
}
