﻿namespace _01.URLDecode
{
    using System;
    using System.Net;

    public class Startup
    {
        public static void Main()
        {
            var url = Console.ReadLine();

            var decodeUrl = WebUtility.UrlDecode(url);

            Console.WriteLine(decodeUrl);
        }
    }
}
