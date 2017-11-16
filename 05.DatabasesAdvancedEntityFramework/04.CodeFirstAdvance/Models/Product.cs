using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public Product()
        {
            this.SalesOfProduct = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Sale> SalesOfProduct { get; set; }

        public string Description { get; set; }
    }
}
