﻿namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public  Car Car { get; set; }

        public int CustomerId { get; set; }
        public  Customer Customer { get; set; }

        [Range(0, double.MaxValue)]
        public double Discount { get; set; }
    }
}
