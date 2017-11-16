namespace _08.RawData
{
    using System.Collections.Generic;

    public class Car
    {
        private string model;
        public Engine engine;
        public Cargo cargo;
        public List<Tyre> tyre;

        public Car(string model, Engine engine, Cargo cargo, List<Tyre> tyre)
        {
            this.Model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tyre = tyre;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
    }
}
