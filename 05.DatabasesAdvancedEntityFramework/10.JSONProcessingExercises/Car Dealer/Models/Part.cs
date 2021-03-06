﻿using System.CodeDom;
using System.Collections.Generic;

namespace Car_Dealer.Models
{
   public class Part
    {
        public Part()
        {
            this.Cars = new List<Car>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
