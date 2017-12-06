namespace _07.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Car>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumation = double.Parse(input[2]);
                var curren = new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumation = fuelConsumation
                };

                dict.Add(model, curren);
            }
            string inputLine;
            
            while ((inputLine=Console.ReadLine()) !="End")
            {
                var inputArgs = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                var carModel = inputArgs[1];
                var distance = int.Parse(inputArgs[2]);

                var current = dict[carModel];

                current.DistanceCalculate(distance);

                dict[carModel] = current;
            }

            foreach (var car in dict)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.Distance}");
            }
            
        }
    }
}
