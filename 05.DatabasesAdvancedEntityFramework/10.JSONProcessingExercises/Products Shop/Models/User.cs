using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Products_Shop.Models
{
    public class User
    {
        //•	Users have an id, first name (optional) and last name (at least 3 characters) and age (optional).

        public User()
        {
            this.SoldProducts = new List<Product>();
            this.Products = new List<Product>();
            this.Friends = new List<User>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        
        public virtual ICollection<Product> Products { get; set; }
        
        public virtual ICollection<Product> SoldProducts { get; set; }
        
        public virtual ICollection<User> Friends { get; set; }

    }
}
