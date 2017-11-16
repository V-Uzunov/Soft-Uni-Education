namespace _01.Vehicles
{
    using System.Dynamic;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double litersPerKm;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            protected set { this.tankCapacity = value; }
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                this.fuelQuantity = value;
            }
        }
        public double LitersPerKm
        {
            get
            {
                return this.litersPerKm;
            }
            protected set
            {
                this.litersPerKm = value;
            }
        }

        public abstract void Drive(double distanceOrLiters);
        public abstract void Refuel(double distanceOrLiters);
        public override string ToString()
        {
            return $"{this.FuelQuantity:F2}";
        }
    }
}
