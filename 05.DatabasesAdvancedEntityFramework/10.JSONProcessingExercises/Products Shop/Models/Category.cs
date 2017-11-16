using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Shop.Models
{
    public class Category
    {
        // •	Categories have an id and name (from 3 to 15 characters)

        public Category()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
