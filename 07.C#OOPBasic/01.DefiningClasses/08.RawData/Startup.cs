namespace _08.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var list = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var speed = int.Parse(carInfo[1]);
                var power = int.Parse(carInfo[2]);
                var weight = int.Parse(carInfo[3]);
                var type = carInfo[4];
                var tire1Pressure = double.Parse(carInfo[5]);
                var tire1Age = int.Parse(carInfo[6]);
                var tire2Pressure = double.Parse(carInfo[7]);
                var tire2Age = int.Parse(carInfo[8]);
                var tire3Pressure = double.Parse(carInfo[9]);
                var tire3Age = int.Parse(carInfo[10]);
                var tire4Pressure = double.Parse(carInfo[11]);
                var tire4Age = int.Parse(carInfo[12]);

                var car = new Car(model, new Engine(speed, power), new Cargo(weight, type), new List<Tyre>
                {
                    new Tyre(tire1Pressure, tire1Age),
                    new Tyre(tire2Pressure, tire2Age),
                    new Tyre(tire3Pressure, tire3Age),
                    new Tyre(tire4Pressure, tire4Age),
                });

                list.Add(car);
            }

            var cargoTypeInput = Console.ReadLine();

            if (cargoTypeInput == "fragile")
            {
                list.Where(x=> x.cargo.CargoType== "fragile")
                    .Where(x=> x.tyre.Any(e=> e.TyrePresure<1))
                    .Select(x=> x.Model)
                    .ToList()
                    .ForEach(x=> Console.WriteLine(x));
            }
            else
            {
                list.Where(x => x.cargo.CargoType == "flamable")
                    .Where(x=> x.engine.EnginePower>250)
                    .Select(x=> x.Model)
                    .ToList()
                    .ForEach(x=> Console.WriteLine(x));
            }
        }
    }
}
