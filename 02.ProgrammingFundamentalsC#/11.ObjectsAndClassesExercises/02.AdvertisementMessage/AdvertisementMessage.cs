using System;
using System.Collections.Generic;
using System.Linq;

class AdvertisementMessage
{
    static void Main()
    {
        List<string> phrases = new List<string>() { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

        List<string> events = new List<string>() { "Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

        List<string> author = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

        List<string> cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        GenerateAndPrintRandomAdvertisement(phrases, events, author, cities);
    }

    private static void GenerateAndPrintRandomAdvertisement(List<string> phrases, List<string> events, List<string> author, List<string> cities)
    {
        var n = int.Parse(Console.ReadLine());
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            var currentPhrases = phrases[rnd.Next(0, phrases.Count)];
            var currentEvents = events[rnd.Next(0, events.Count)];
            var currentAuthor = author[rnd.Next(0, author.Count)];
            var currentCities = cities[rnd.Next(0, cities.Count)];
            Console.WriteLine($"{currentPhrases} {currentEvents} {currentAuthor} - {currentCities}");
        }
    }
}