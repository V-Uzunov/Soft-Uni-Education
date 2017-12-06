namespace _03.Ferrari
{
    using System.Net.Http.Headers;
    using System.Text;

    public abstract class Car : ICar
    {
        private string model;
        private string driver;

        public Car(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public string Driver
        {
            get { return this.driver; }
            private set { this.driver = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Model}/{this.PushBrakes()}/{this.PushGasPedal()}/{this.Driver}");

            return sb.ToString().Trim();
        }

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }
    }
}
