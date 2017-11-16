namespace CarDealer.Data.Models
{
    public class PartsCar
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int PartsId { get; set; }
        public Part Part { get; set; }
    }
}
