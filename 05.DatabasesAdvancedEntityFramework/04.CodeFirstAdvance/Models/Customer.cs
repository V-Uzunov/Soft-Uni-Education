using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public Customer()
        {
            this.SalesForCustomer = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> SalesForCustomer { get; set; }

        public int Age { get; set; }
    }
}
