namespace _07.SpeedRacing
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumation { get; set; }
        public int Distance { get; set; }

        public void DistanceCalculate(int distance)
        {
            var needFuel = FuelConsumation * distance;
            if (needFuel > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                Distance += distance;
                FuelAmount -= needFuel;
            }
        }
    }
}
