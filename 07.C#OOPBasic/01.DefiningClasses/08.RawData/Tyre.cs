namespace _08.RawData
{
    public class Tyre
    {
        private double tyrePresure;
        private int tyreAge;

        public Tyre(double tyrePresure, int tyreAge)
        {
            this.TyrePresure = tyrePresure;
            this.TyreAge = tyreAge;
        }

        public double TyrePresure
        {
            get { return this.tyrePresure; }
            set { this.tyrePresure = value; }
        }

        public int TyreAge
        {
            get { return this.tyreAge; }
            set { this.tyreAge = value; }
        }
    }
}
