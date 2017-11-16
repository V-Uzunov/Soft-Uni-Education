namespace _02.ValidateURL
{
    using System;
    using System.Net;

    public class Startup
    {
        public static void Main()
        {
            var url = Console.ReadLine();

            var decodeUrl = WebUtility.UrlDecode(url);

            var uri = new Uri(decodeUrl);

            var protocol = uri.Scheme;
            var host = uri.Host;
            var port = uri.Port;
            var path = uri.LocalPath;
            var query = uri.Query;
            var fragment = uri.Fragment;

            if (protocol != string.Empty && host != string.Empty && port != 0 && path != string.Empty)
            {
                Console.WriteLine($"Protocol: {protocol}");
                Console.WriteLine($"Host: {host}");
                Console.WriteLine($"Port: {port}");
                Console.WriteLine($"Path: {path}");
                if (query != string.Empty)
                {
                    Console.WriteLine($"Query: {query}");
                }
                if (fragment != string.Empty)
                {
                    Console.WriteLine($"Fragment: {fragment}");
                }

            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
