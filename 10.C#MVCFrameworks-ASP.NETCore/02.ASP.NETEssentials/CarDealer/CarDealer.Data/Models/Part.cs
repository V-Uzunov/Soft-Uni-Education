﻿namespace CarDealer.Data.Models
{
    using System.Collections.Generic;

    public class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public  ICollection<PartsCar> Cars { get; set; } = new List<PartsCar>();

        public int SupplierId { get; set; }
        public  Supplier Supplier { get; set; }
    }
}
