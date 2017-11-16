using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Products_Shop.Models
{
    public class Product
    {
        // •	Products have an id, name (at least 3 characters), price, buyerId (optional) and sellerId as IDs of users.
        public Product()
        {
            this.Categories = new List<Category>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }


        public int SellerId { get; set; }


        public User Seller { get; set; }

        public int? BuyerId { get; set; }

        public User Buyer { get; set; }

        [JsonIgnore]
        public virtual ICollection<Category> Categories { get; set; }

    }


}
