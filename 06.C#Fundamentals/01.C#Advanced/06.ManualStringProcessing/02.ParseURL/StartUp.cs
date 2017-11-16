namespace _02.ParseURL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var separator = "://";

            var urlTokens = input
                .Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

            if (urlTokens.Length != 2 || urlTokens[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var protocol = urlTokens[0];
                var indexRes = urlTokens[1].IndexOf('/');
                var server = urlTokens[1].Substring(0, indexRes);
                var resources = urlTokens[1].Substring(indexRes + 1);

                Console.WriteLine($"Protocol = {protocol}\nServer = {server}\nResources = {resources}");
            }
        }
    }
}
