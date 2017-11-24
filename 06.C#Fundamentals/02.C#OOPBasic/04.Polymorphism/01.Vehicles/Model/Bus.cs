﻿namespace _01.Vehicles
{
    using System;

    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double maxDistance = base.FuelQuantity / base.LitersPerKm;

            if (maxDistance >= distance)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                base.FuelQuantity -= distance * base.LitersPerKm;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            double maxDistance = base.FuelQuantity / (base.LitersPerKm - 1.4);

            if (maxDistance >= distance)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                base.FuelQuantity -= distance * (base.LitersPerKm - 1.4);
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (liters > base.TankCapacity - base.FuelQuantity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }

            base.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return "Bus: " + base.ToString();
        }
    }
}