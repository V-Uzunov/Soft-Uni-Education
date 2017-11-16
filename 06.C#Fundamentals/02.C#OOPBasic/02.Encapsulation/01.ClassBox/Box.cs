namespace _01.ClassBox
{
    using System;

    public class Box
    {
        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        private double lenght;
        private double width;
        private double height;

        public double Length
        {
            get { return this.lenght; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                this.lenght = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * (this.Width * this.Length) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        }
        public double Volume()
        {
            return this.Length * this.Height * this.Width;
        }
        public override string ToString()
        {
            return
                $"Surface Area - {SurfaceArea():F2}\nLateral Surface Area - {LateralSurfaceArea():F2}\nVolume - {Volume():F2}";
        }
    }
}
