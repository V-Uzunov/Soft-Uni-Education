﻿using System;
using System.Collections.Generic;
using TrafficLights.Models;

namespace TrafficLights
{
    using TrafficLights = Models.TrafficLights;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var currentLights = Console.ReadLine()
                .Split();

            var traffictLights = new List<ITrafficLight>();

            foreach (var light in currentLights)
            {
                traffictLights.Add(new TrafficLights(light));
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                traffictLights.ForEach(c => c.Change());

                Console.WriteLine(string.Join(" ", traffictLights));
            }
        }
    }
}
