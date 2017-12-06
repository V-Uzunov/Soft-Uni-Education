namespace _03.RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var validUrl = new Dictionary<string, HashSet<string>>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();
                var path = $"/{tokens[0]}";
                var method = tokens[1];

                if (!validUrl.ContainsKey(path))
                {
                    validUrl[path] = new HashSet<string>();
                }
                validUrl[path].Add(method);
            }

            var request = Console.ReadLine();
            var parts = request.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var responseStatus = 404;
            var resposneText = "NotFound";

            var requestMetod = parts[0];
            var requestUrl = parts[1];
            var requestProtocol = parts[2];

            if (validUrl.ContainsKey(requestUrl) && validUrl[requestUrl].Contains(requestMetod.ToLower()))
            {
                responseStatus = 200;
                resposneText = "OK";
            }

            Console.WriteLine($"{requestProtocol} {responseStatus} {resposneText}");
            Console.WriteLine($"Content-Length: {resposneText.Length}");
            Console.WriteLine("Content-Type: text/plain");
            Console.WriteLine();
            Console.WriteLine(resposneText);
        }
    }
}
